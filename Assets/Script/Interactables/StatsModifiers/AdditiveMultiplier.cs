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
            Debug.Log("amount to add : " + amount + " original amount : " + modAmount);
            return modAmount + amount;
        }

        public override int Modify(int modAmount)
        {
            Debug.Log("amount to add : " + amount + " original amount : " + modAmount);
            return (int)(modAmount + amount);
        }
    }
}
