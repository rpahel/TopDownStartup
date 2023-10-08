using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Stats Modifier/Additive Multiplier")]
    public class AdditiveMultiplier : StatsModifier
    {
        public override float Modify(float modAmount)
        {
            return modAmount + amount;
        }

        public override int Modify(int modAmount)
        {
            return (int)(modAmount + amount);
        }
    }
}
