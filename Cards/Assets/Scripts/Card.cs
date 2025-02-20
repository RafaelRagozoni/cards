using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Cards
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card: ScriptableObject {
        public string cardName;
        public Color cardColor;
        public int health;
        public int damage; 
        public List<CardType> cardType;
        public List<CardEfect> cardSimpleEfects;
        public List<CardEfect> cardEfects;
        public int[] cardEfectsIds;
        public int[] cardPrices;
        public string efectText;
        public Sprite cardSprite;
        public enum CardType{
            Inocencia,
            Agressividade,
            Paciencia,
            Gratidao,
            Desconfianca,
            Impiedade
        }
        public enum CardEfect{
            OnPlay,
            OnDeath,
            Trigger,
            Cast,
            Upgrade
        }
        private static readonly Dictionary<CardType, Color> cardTypeColors = new Dictionary<CardType, Color>
        {

            { CardType.Inocencia,       new Color(100f / 255f, 100f / 255f, 100f / 255f) }, 
            { CardType.Agressividade,   new Color(100f / 255f, 0f   / 255f, 0f   / 255f) },     
            { CardType.Paciencia,       new Color(0f   / 255f, 0f   / 255f, 100f / 255f) },     
            { CardType.Gratidao,        new Color(0f   / 255f, 100f / 255f, 0f   / 255f) },     
            { CardType.Desconfianca,    new Color(100f / 255f, 100f / 255f, 0f   / 255f) },  
            { CardType.Impiedade,       new Color(100f / 255f, 0f   / 255f, 100f / 255f) }    
        };
        private static readonly Dictionary<CardEfect, int> cardEfectIconId = new Dictionary<CardEfect, int>
        {
            { CardEfect.OnPlay,    0},
            { CardEfect.OnDeath,   1},
            { CardEfect.Trigger,   2},    
            { CardEfect.Cast,      3},  
            { CardEfect.Upgrade,   4} 
        };

        private void UpdateCardEfects()
        {
            cardEfectsIds = new int[cardEfects.Count];
            int i = 0;
            foreach (CardEfect effect in cardEfects){
                if (cardEfectIconId.TryGetValue(effect, out int iconId)){
                    cardEfectsIds[i] = iconId;
                    i++;
                }
            }
        }

        private void UpdateCardColor()
        {
            CardType firstCardType = cardType[0];
            if (cardTypeColors.TryGetValue(firstCardType, out Color color))
                cardColor = color;
        }

        private void OnValidate()
        {
            UpdateCardColor();
            UpdateCardEfects();
        }

    }

}