using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ItemHolder : MonoBehaviour
    {
        private List<Item> _items = new List<Item>();
        public List<Item> Items => _items;
    }
}
