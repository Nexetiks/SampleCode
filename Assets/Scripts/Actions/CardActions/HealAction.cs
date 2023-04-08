using UnityEngine;

namespace Actions
{
    public class HealAction : CardAction
    {
        [SerializeField]
        private float amount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.CardOwner.DamageableController.AddHp(amount);
        }
    }
}