namespace Game
{
    public class OneTimeUseCondition : Condition
    {
        private bool hasBeenInteracted = true;

        public override bool IsConditionMet()
        {
            return hasBeenInteracted;
        }

        public void Interacted()
        {
            hasBeenInteracted = false;
        }
    }
}
