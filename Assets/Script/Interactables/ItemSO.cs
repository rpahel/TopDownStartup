using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Item")]
    public class ItemSO : ScriptableObject
    {
        [System.Serializable]
        private struct Modifier
        {
            [SerializeField] private float _amount;
            [SerializeField] private int _weight;
            [SerializeField] private StatsModifier _modifier;

            public Modifier(float  amount, int weight, StatsModifier mod)
            {
                _amount = amount;
                _weight = weight;
                _modifier = mod;
            }

            public float Amount => _amount;
            public int Weight => _weight;
            public StatsModifier StatsModifier => _modifier;
        }


        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private List<Modifier> _modifiers = new();

        public GameObject ItemPrefab => itemPrefab;

        public List<StatsModifier> GiveModifiers()
        {
            List<StatsModifier> mods = new List<StatsModifier>();
            foreach (var modifier in _modifiers)
            {
                mods.Add(modifier.StatsModifier.GetClone(modifier.Amount, modifier.Weight));
            }
            return mods;
        }
    }
}
