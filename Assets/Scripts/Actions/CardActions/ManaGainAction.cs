using UnityEngine;

namespace Actions
{
    public class ManaGainAction : CardAction
    {
        [SerializeField]
        private int amount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.CardOwner.ManaController.AddMana(amount);
        }
    }
}