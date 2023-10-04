using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class StatsModifier : ScriptableObject
    {
        private float amount;
        public abstract float Modify();
    }
}
