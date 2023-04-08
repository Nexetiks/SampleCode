using System;

namespace Actions
{
    [Serializable]
    public abstract class CardAction
    {
        public abstract void Execute(CardActionsContext cardActionsContext);
    }
}