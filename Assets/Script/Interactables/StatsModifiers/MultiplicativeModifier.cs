using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Stats Modifier/Multiplicative Modifier")]
    public class MultiplicativeModifier : StatsModifier
    {
        public override float Modify(float modAmount)
        {
            return modAmount * amount;
        }

        public override int Modify(int modAmount)
        {
            return (int)(modAmount * amount);
        }
    }
}
