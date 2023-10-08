using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public enum Stat
    {
        FireRate,
        Damage,
    }

    public class StatsModifier : ScriptableObject
    {
        protected Stat statToModify;
        protected float amount;
        protected int weight;

        public virtual float Modify(float a)
        {
            return amount;
        }

        public virtual int Modify(int a)
        {
            return (int)amount;
        }

        public StatsModifier GetClone(float cloneAmount, int cloneWeight, Stat stat)
        {
            StatsModifier mod = CreateInstance<StatsModifier>();
            mod.amount = amount;
            mod.weight = weight;
            mod.statToModify = stat;
            return mod;
        }

    }
}
