using UnityEngine;

namespace Game
{
    [System.Serializable]
    public abstract class Condition : MonoBehaviour
    {
        public abstract bool IsConditionMet();
    }
}
