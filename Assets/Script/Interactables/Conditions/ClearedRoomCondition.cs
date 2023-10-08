namespace Game
{
    public class ClearedRoomCondition : Condition
    {
        private bool _isRoomCleared;
        public override bool IsConditionMet()
        {
            return _isRoomCleared;
        }

        public void RoomCleared()
        {
            _isRoomCleared = true;
        }
    }
}
