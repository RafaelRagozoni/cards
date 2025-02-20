// using System;
// using System.Numerics;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using Quaternion = UnityEngine.Quaternion;

// public class CardMovement : MonoBehaviour, IDragHandler,
//     IBeginDragHandler,
//     IEndDragHandler,
//     IPointerEnterHandler,
//     IPointerExitHandler,
//     IPointerUpHandler,
//     IPointerDownHandler

// {
//     private Canvas canvas;
//     private RectTransform rectTransform;
//     private UnityEngine.Vector2 originalLocalPointerPosition;
//     private UnityEngine.Vector3 originalPanelLocalPosition;
//     private UnityEngine.Vector3 originalScale;
//     private UnityEngine.Quaternion originalRotation;
//     private UnityEngine.Vector3 originalPosition;
//     private int currentState;
//     [SerializeField] private float selectScale = 1.1f;
//     [SerializeField] private UnityEngine.Vector2 cardPlay;
//     [SerializeField] private UnityEngine.Vector3 playPosition;
//     [SerializeField] private GameObject glowEffect;
//     [SerializeField] private GameObject playArrow;

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         BeginDragEvent.Invoke(this);
//         isDragging = true;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         throw new NotImplementedException();
//     }

//     void Awake()
//     {
//         rectTransform = GetComponent<RectTransform>();
//         canvas = GetComponentInParent<Canvas>();
//         originalScale = rectTransform.localScale;
//         originalPosition = rectTransform.localPosition;
//         originalRotation = rectTransform.localRotation;
//     }
//     void Update()
//     {
//     }

    


// }
