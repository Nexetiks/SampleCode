using UnityEngine;

namespace Actions
{
    public class HealAction : CardActionBase
    {
        [SerializeField]
        private int amount;

        public override void Execute(CardActionsContext cardActionsContext)
        {
            cardActionsContext.CardOwner.DamageableController.AddHp(amount);
        }
    }
}