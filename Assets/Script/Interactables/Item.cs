using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Item
    {
        private List<object> _modObjects = new();
        private List<StatsModifier> _mods = new();

        public void InitializeItem(List<StatsModifier> mods)
        {
            _mods = mods;

        }
    }
}
