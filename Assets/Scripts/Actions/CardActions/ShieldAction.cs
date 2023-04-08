using UnityEngine;

namespace Actions
{
    public class ShieldAction : CardAction
    {
        [SerializeField]
        private float amount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.CardOwner.DamageableController.AddShield(amount);
        }
    }
}