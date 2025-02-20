using System;
using System.Collections.Generic;
using System.Numerics;
using Cards;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public DeckManager deckManager;
    public GameObject cardPrefab; //assign card prefab in inspector
    public Transform handTransform; //root of the hand position
    public float fanSpread = -7.5f;
    public float cardSpacing = 150f;
    public float verticalSpacing = 50f;
    public List<GameObject> cardsInHand; //hold a list of card objects in our hand

    void Start()
    {   
        cardsInHand = new();
    }

    public void AddCardToHand(Card cardData)
    {
        //Set a maximum handSize
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, UnityEngine.Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        newCard.GetComponent<CardDisplay>().cardData = cardData;
        UpdateHandVisuals();
    }
    void Update()
    {
        // UpdateHandVisuals();
    }

    private void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;

        if (cardCount == 1){
            cardsInHand[0].transform.SetLocalPositionAndRotation(new UnityEngine.Vector3(0f,0f,0f), UnityEngine.Quaternion.Euler(0f,0f,0f));
            return;
        }

        
        for (int i = 0; i < cardCount; i++){
            float rotationAngle = fanSpread * (i -(cardCount - 1)/2f);
            cardsInHand[i].transform.localRotation = UnityEngine.Quaternion.Euler(0f,0f,rotationAngle);

            float horizontalOffset = cardSpacing * (i -(cardCount - 1)/2f);
            float normalizedPosition = 2f * i / (cardCount - 1) - 1f;
            float verticalOffset = verticalSpacing * (1 - normalizedPosition*normalizedPosition);
            cardsInHand[i].transform.localPosition = new UnityEngine.Vector3(horizontalOffset, verticalOffset,0f);
        }
    }
}
