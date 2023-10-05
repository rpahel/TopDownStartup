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
            //Item newitem
            //newitem.InitializeItem(item.GiveModifiers()); // <-- Still needs to be implemented !
        }
    }
}
