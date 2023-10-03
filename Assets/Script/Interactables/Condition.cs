using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public abstract class Condition
    {
        public abstract bool IsConditionMet();
    }
}
