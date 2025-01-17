using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game
{
    public class ItemLootSystem : LootSystem<ItemSO>
    {
        public void SpawnItem()
        {
            ItemSO item = GetLoot();

            Assert.IsNotNull(item);

            GameObject go = Instantiate(item.ItemPrefab, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);

            ItemHolder holder = go.AddComponent<ItemHolder>();
            (List<StatsModifier>, List<Stat>, List<int>) temp = item.GiveModifiers();
            holder.GenerateItem(temp.Item1, temp.Item2, temp.Item3);
        }
    }
}
