using UnityEngine;

namespace Actions
{
    public class ShieldGainAction : CardActionBase
    {
        [SerializeField]
        private int amount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.CardOwner.DamageableController.AddShield(amount);
        }
    }
}