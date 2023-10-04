namespace Game
{
    public class OneTimeUseCondition : Condition
    {
        private bool hasBeenInteracted;

        public override bool IsConditionMet()
        {
            if(!hasBeenInteracted)
            {
                hasBeenInteracted = true;
                return hasBeenInteracted;
            }
            return !hasBeenInteracted;
        }
    }
}
