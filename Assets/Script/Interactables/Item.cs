using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Item
    {
        private List<object> _modObjects = new ();
        private List<StatsModifier> _modifiers;
        private List<Stat> _stats;
        private List<int> _weights;

        public List<object> ModObjects => _modObjects;
        public List<StatsModifier> Modifiers => _modifiers;

        public Item(List<StatsModifier> mods, List<Stat> stats, List<int> weights)
        {
            _modifiers = mods;
            _stats = stats;
            _weights = weights;
        }

        public void AddObject(object obj)
        {
            _modObjects.Add(obj);
        }

        public (StatsModifier, Stat, int) GetModifier(int index)
        {
            StatsModifier modifier = _modifiers[index];
            Stat stat = _stats[index];
            int weight = _weights[index];
            return (modifier, stat, weight);
        }

    }
}
