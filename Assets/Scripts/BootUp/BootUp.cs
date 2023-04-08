using Cards;
using Metrics;
using UnityEngine;

namespace BootUp
{
    public class BootUp : MonoBehaviour
    {
        [SerializeField]
        private CardsDeckResolver playerCardsResolver;
        [SerializeField]
        private CardsDeckResolver enemyCardsResolver;

        [SerializeField]
        private Team turnOwner;
        [SerializeField]
        private int roundNumber;

        private void Start()
        {
            playerCardsResolver.Initialize();
            enemyCardsResolver.Initialize();
            playerCardsResolver.DrawTheCards();
            enemyCardsResolver.DrawTheCards();
        }
    }
}