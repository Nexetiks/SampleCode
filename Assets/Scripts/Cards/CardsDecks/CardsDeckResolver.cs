using System;
using System.Collections.Generic;
using Actions;
using CharacterSystem;
using Extensions;
using UnityEngine;

namespace Cards
{
    [Serializable]
    public class CardsDeckResolver
    {
        [SerializeField]
        private CardsDeck cardsDeck;
        [SerializeField]
        private int maximumCardInHand;
        [SerializeField]
        private CharacterContext ownerCharacterContext;
        private List<Card> cardsHand;
        private List<Card> cardsDrawPile;
        private List<Card> cardsDiscardPile;

        public void Initialize()
        {
            cardsDrawPile = new List<Card>();

            foreach (Card card in cardsDeck.Cards)
            {
                cardsDrawPile.Add(card);
            }

            cardsHand = new List<Card>();
            cardsDiscardPile = new List<Card>();

            if (maximumCardInHand > cardsDrawPile.Count)
            {
                throw new Exception($"You want to add more cards ({maximumCardInHand}) then you have ({cardsDrawPile.Count})");
            }
        }

        public void DrawTheCards()
        {
            for (int i = 0; i < maximumCardInHand; i++)
            {
                if (cardsDrawPile.Count == 0)
                {
                    ShuffleDiscardPileToDrawPile();
                }

                if (cardsDrawPile.TryRemoveRandomElement(out Card cardToAddAtHand))
                {
                    cardsHand.Add(cardToAddAtHand);
                    cardToAddAtHand.OnDrawn(new CardActionsContext(ownerCharacterContext, default));
                }
                else
                {
                    return;
                }
            }
        }

        public void PlayTheCard(Card card, CharacterContext target)
        {
            if (!cardsHand.Contains(card))
            {
                throw new Exception($"You can't Play Card that You do not have");
            }

            if (ownerCharacterContext.ManaController.Mana < card.ManaCost)
            {
                Debug.Log($"Not enough mana, you need {card.ManaCost} but you have {ownerCharacterContext.ManaController.Mana}");
                return;
            }

            ownerCharacterContext.ManaController.UseMana(card.ManaCost);
            card.OnUsed(new CardActionsContext(ownerCharacterContext, target));
        }

        public void DiscardCart(Card card, CharacterContext target)
        {
            if (!cardsHand.Contains(card))
            {
                throw new Exception($"You can't Discard Card that You do not have");
            }

            card.OnDiscard(new CardActionsContext(ownerCharacterContext, target));
            cardsHand.Remove(card);
            cardsDiscardPile.Add(card);
        }

        private void ShuffleDiscardPileToDrawPile()
        {
            cardsDrawPile.AddRange(cardsDiscardPile);
        }
    }
}