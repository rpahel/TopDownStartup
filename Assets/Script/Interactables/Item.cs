using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Item
    {
        private List<object> _modObjects;
        private List<StatsModifier> _mods;

        public List<object> ModObjects => _modObjects;
        public List<StatsModifier> Mods => _mods;

        public Item(List<StatsModifier> mods)
        {
            _mods = mods;
            _modObjects = new();
        }

    }
}
