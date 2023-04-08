using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    [Serializable]
    [CreateAssetMenu(fileName = "Card Deck", menuName = "ScriptableObjects/Card Deck", order = 1)]
    public class CardsDeck : ScriptableObject
    {
        [SerializeField]
        private List<Card> cards;

        public List<Card> Cards => cards;
    }
}