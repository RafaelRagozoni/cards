using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Quaternion = UnityEngine.Quaternion;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler,
IPointerEnterHandler,IPointerExitHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private UnityEngine.Vector2 originalLocalPointerPosition;
    private UnityEngine.Vector3 originalPanelLocalPosition;
    private UnityEngine.Vector3 originalScale;
    private UnityEngine.Quaternion originalRotation;
    private UnityEngine.Vector3 originalPosition;
    private int currentState;
    [SerializeField] private float selectScale = 1.1f;
    [SerializeField] private UnityEngine.Vector2 cardPlay;
    [SerializeField] private UnityEngine.Vector3 playPosition;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject playArrow;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;
        originalRotation = rectTransform.localRotation;
    }
    void Update()
    {
        switch (currentState)
        {
            case 1:
                HandleHoverState();
                break;
            case 2:
                HandleDragState();
                if (!Input.GetMouseButton(0)) { TransitionToState0(); }
                break;
            case 3:
                HandlePlayState();
                if (!Input.GetMouseButton(0)) { TransitionToState0(); }
                break;
            default:
                break;
        }
    }

    private void CardPositionToOriginal(){
        rectTransform.localScale = originalScale;
        rectTransform.localRotation = originalRotation;
        rectTransform.localPosition = originalPosition;
    }

    private void TransitionToState0()
    {
        currentState = 0;
        CardPositionToOriginal();
        glowEffect.SetActive(false); //Disable glow
        playArrow.SetActive(false); //Disable Play arrow
    }

    private void HandlePlayState()
    {
        rectTransform.localPosition = playPosition;
        rectTransform.localRotation = Quaternion.identity;
        if(Input.mousePosition.y < cardPlay.y){
            currentState = 2;
            playArrow.SetActive(false);
        }
    }

    private void HandleDragState()
    {
        rectTransform.localRotation = Quaternion.identity;
    }

    private void HandleHoverState()
    {
        glowEffect.SetActive(true);
        rectTransform.localScale = originalScale * selectScale;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentState == 2) {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),eventData.position, eventData.pressEventCamera, out UnityEngine.Vector2 localPointerPosition)){
                localPointerPosition /= canvas.scaleFactor;
                
                UnityEngine.Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
                rectTransform.localPosition = originalPanelLocalPosition + offsetToOriginal;

                if (rectTransform.localPosition.y > cardPlay.y){
                    currentState = 3;
                    playArrow.SetActive(true);
                    rectTransform.localPosition = playPosition;
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentState == 1) {
            currentState = 2;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),eventData.position, eventData.pressEventCamera, out originalLocalPointerPosition);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentState == 0 ) {
            CardPositionToOriginal();
            currentState = 1;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentState == 1) {
            currentState = 0;
            TransitionToState0();
        }
    }
}
