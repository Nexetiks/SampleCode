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
            cardsDrawPile = new List<Card>(cardsDeck.Cards);

            cardsHand = new List<Card>();
            cardsDiscardPile = new List<Card>();
        }

        public void DrawTheCards()
        {
            if (maximumCardInHand > cardsDrawPile.Count)
            {
                throw new Exception($"You want to add more cards ({maximumCardInHand}) than you have ({cardsDrawPile.Count})");
            }

            for (int i = 0; i < maximumCardInHand; i++)
            {
                if (cardsDrawPile.Count == 0)
                {
                    ShuffleDiscardPileToDrawPile();
                }

                if (cardsDrawPile.TryRemoveRandomElement(out Card cardToAddToHand))
                {
                    cardsHand.Add(cardToAddToHand);
                    cardToAddToHand.OnDrawn(new CardActionsContext(ownerCharacterContext, default));
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

            if (cardsHand.Contains(card))
            {
                cardsHand.Remove(card);
                ownerCharacterContext.ManaController.RemoveMana(card.ManaCost);
                card.OnUsed(new CardActionsContext(ownerCharacterContext, target));
                cardsDiscardPile.Add(card);
            }
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
            cardsDrawPile = new List<Card>(cardsDiscardPile);
            cardsDiscardPile.Clear();
        }
    }
}