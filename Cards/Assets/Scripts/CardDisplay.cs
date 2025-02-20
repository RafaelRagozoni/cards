using UnityEngine;
using Cards;
using UnityEngine.UI;
using TMPro;
using System;

public class CardDisplay : MonoBehaviour
{


    public Card cardData;
    public Image cardBackground;
    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text efectText;
    public TMP_Text[] typeTexts;
    public GameObject miniIcons;
    public GameObject altIcons;
    public GameObject[] efectIcons;

    public void UpdateCardDisplay()
    {
        GameObject miniIcon = new();
        RectTransform miniIconRectTransform = new();
        GameObject altIcon = new();
        RectTransform altIconRectTransform = new();
        nameText.text = cardData.cardName;
        healthText.text = cardData.health.ToString();
        damageText.text = cardData.damage.ToString();
        int i = 0;
        for(i = 0; i<6;i++){
            typeTexts[i].text = cardData.price[i].ToString();
        }
        cardBackground.color = cardData.cardColor;
        cardImage.sprite = cardData.cardSprite;
        i = 0;
        foreach (int effect in cardData.cardEfectsIds){
            miniIcon = Instantiate(efectIcons[effect]);
            miniIcon.transform.SetParent(miniIcons.transform);
            miniIconRectTransform = miniIcon.GetComponent<RectTransform>();
            miniIconRectTransform.anchorMin = new Vector2(0, 1);
            miniIconRectTransform.anchorMax = new Vector2(0, 1);
            miniIconRectTransform.pivot = new Vector2(0, 1);
            miniIconRectTransform.anchoredPosition = new Vector2(0.3f*i, 0); // Position at (0, 0)
            miniIcon.transform.localScale = new Vector3(1, 1, 1);

            altIcon = Instantiate(efectIcons[effect]);
            altIcon.transform.SetParent(altIcons.transform);
            altIconRectTransform = altIcon.GetComponent<RectTransform>();
            altIconRectTransform.anchorMin = new Vector2(0, 1);
            altIconRectTransform.anchorMax = new Vector2(0, 1);
            altIconRectTransform.pivot = new Vector2(0, 1);
            altIconRectTransform.anchoredPosition = new Vector2(0.4f*i, 0); // Position at (0, 0)
            altIcon.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            i++;
        }


        efectText.text = cardData.efectText;
    } 

    void Start()
    {
        UpdateCardDisplay();
    }
}
