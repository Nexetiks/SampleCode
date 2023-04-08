using UnityEngine;

namespace Actions
{
    public class AOEDamage : CardAction
    {
        [SerializeField]
        private float targetAmount;
        [SerializeField]
        private float ownerAmount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.Target.DamageableController.DamageCharacter(targetAmount);
            cardActionsContext.CardOwner.DamageableController.DamageCharacter(ownerAmount);
        }
    }
}