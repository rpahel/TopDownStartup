using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class LootSystem<T> : MonoBehaviour
    {
        [System.Serializable]
        private struct WeightedValue
        {
            [SerializeField] private T _value;
            [SerializeField] private float _weight;

            public WeightedValue(T value, float weight)
            {
                _value = value;
                _weight = weight;
            }

            public T Value => _value;
            public float Weight => _weight;
        }

        [SerializeField] private List<WeightedValue> _lootList = new();

        public T GetLoot()
        {
            if (_lootList == null || _lootList.Count <= 0) throw new ArgumentException(gameObject.name + "'s loot list isn't initialised or is empty !");

            T output = default;
            float totalWeight = _lootList.Sum(i => i.Weight);
            
            float randomValue = UnityEngine.Random.Range(0, totalWeight);

            float processedWeight = 0;
            foreach(WeightedValue val in _lootList)
            {
                processedWeight += val.Weight;
                if(randomValue <= processedWeight)
                {
                    output = val.Value;
                    break;
                }
            }

            return output;
        }
    }
}
