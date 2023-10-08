using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ItemInventory : MonoBehaviour
    {
        [SerializeField] private PlayerStatsReference _playerStats;

        private List<Item> _items = new();

        public void AddItem(Item item)
        {
            _items.Add(item);
            for(int i = 0; i < item.Modifiers.Count;  i++)
            {
                (StatsModifier, Stat, int) modif = item.GetModifier(i);
                switch (modif.Item2)
                {
                    case Stat.Damage:
                        item.AddObject(_playerStats.Instance.DamageAlterable.AddTransformator(x => modif.Item1.Modify(x), modif.Item3));
                        Debug.Log(_playerStats.Instance.DamageAlterable.CalculateValue());
                        break;
                    case Stat.FireRate:
                        item.AddObject(_playerStats.Instance.FireRateAlterable.AddTransformator(x => modif.Item1.Modify(x), modif.Item3));
                        break;

                }
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            ItemHolder holder;
            if (other.gameObject.TryGetComponent<ItemHolder>(out holder))
            {
                AddItem(holder.HeldItem);
                Destroy(other.gameObject);
            }
        }
    }
}
