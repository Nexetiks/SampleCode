using UnityEngine;

namespace Actions
{
    public class DamageAction : CardActionBase
    {
        [SerializeField]
        private int amount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.Target.DamageableController.DamageCharacter(amount);
        }
    }
}