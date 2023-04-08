using System.Collections.Generic;
using Actions;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
    public class Card : ScriptableObject
    {
        [field: SerializeField]
        public string NameOfCard { get; private set; }
        [field: SerializeField]
        public string Description { get; private set; }
        [field: SerializeField]
        public int ManaCost { get; private set; }

        [SerializeReference, ReferencePicker(TypeGrouping = TypeGrouping.ByFlatName)]
        private List<CardAction> onDrawn = new List<CardAction>();
        [SerializeReference, ReferencePicker(TypeGrouping = TypeGrouping.ByFlatName)]
        private List<CardAction> onUsed = new List<CardAction>();
        [SerializeReference, ReferencePicker(TypeGrouping = TypeGrouping.ByFlatName)]
        private List<CardAction> onDiscard = new List<CardAction>();

        public void OnDrawn(CardActionsContext cardActionsContext)
        {
            ExecuteAllActions(onDrawn, cardActionsContext);
        }

        public void OnUsed(CardActionsContext cardActionsContext)
        {
            ExecuteAllActions(onUsed, cardActionsContext);
        }

        public void OnDiscard(CardActionsContext cardActionsContext)
        {
            ExecuteAllActions(onDiscard, cardActionsContext);
        }

        private void ExecuteAllActions(List<CardAction> actions, CardActionsContext cardActionsContext)
        {
            int actionsCount = actions.Count;

            for (int i = 0; i < actionsCount; i++)
            {
                actions[i].Execute(cardActionsContext);
            }
        }
    }
}