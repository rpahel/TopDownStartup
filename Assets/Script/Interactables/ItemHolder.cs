using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ItemHolder : MonoBehaviour
    {
        private Item _item;
        public Item HeldItem => _item;

        public void GenerateItem(List<StatsModifier> modifiers, List<Stat> stats, List<int> weights)
        {
            _item = new Item(modifiers, stats, weights);
        }

    }
}
