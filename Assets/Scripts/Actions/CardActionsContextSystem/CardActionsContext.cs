using CharacterSystem;

namespace Actions
{
    public class CardActionsContext
    {
        public CharacterContext CardOwner;
        public CharacterContext Target;

        public CardActionsContext(CharacterContext cardOwner, CharacterContext target)
        {
            CardOwner = cardOwner;
            Target = target;
        }
    }
}