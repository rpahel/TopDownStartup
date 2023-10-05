using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class StatsModifier : ScriptableObject
    {
        private float _amount;
        private int _weight;

        public abstract float Modify();

        public StatsModifier GetClone(float amount, int weight)
        {
            StatsModifier mod = CreateInstance<StatsModifier>();
            mod._amount = amount;
            mod._weight = weight;
            return mod;
        }
    }
}
