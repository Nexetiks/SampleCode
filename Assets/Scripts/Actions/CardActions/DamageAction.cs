using UnityEngine;

namespace Actions
{
    public class DamageAction : CardAction
    {
        [SerializeField]
        private float amount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.Target.DamageableController.DamageCharacter(amount);
        }
    }
}