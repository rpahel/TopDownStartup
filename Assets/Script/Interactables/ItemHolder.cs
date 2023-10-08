using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ItemHolder : MonoBehaviour
    {
        private Item _items;
        public Item HeldItem => _items;

        public void GenerateItem(List<StatsModifier> modifiers)
        {
            Item item = new Item(modifiers);
        }
    }
}
