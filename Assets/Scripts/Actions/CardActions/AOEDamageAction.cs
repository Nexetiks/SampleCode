using UnityEngine;

namespace Actions
{
    public class AOEDamage : CardActionBase
    {
        [SerializeField]
        private int targetAmount;
        [SerializeField]
        private int ownerAmount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.Target.DamageableController.DamageCharacter(targetAmount);
            cardActionsContext.CardOwner.DamageableController.DamageCharacter(ownerAmount);
        }
    }
}