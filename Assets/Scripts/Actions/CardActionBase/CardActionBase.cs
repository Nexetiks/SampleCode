using System;

namespace Actions
{
    [Serializable]
    public abstract class CardActionBase
    {
        public abstract void Execute(CardActionsContext cardActionsContext);
    }
}