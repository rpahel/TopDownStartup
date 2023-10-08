using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            [SerializeField] private Stat _statToModify;

            public Modifier(float  amount, int weight, StatsModifier mod, Stat stat)
            {
                _amount = amount;
                _weight = weight;
                _modifier = mod;
                _statToModify = stat;
            }

            public float Amount => _amount;
            public int Weight => _weight;
            public StatsModifier StatsModifier => _modifier;
            public Stat StatToModify => _statToModify;
        }


        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private List<Modifier> _modifiers = new();
        [SerializeField] private PlayerReference _playerReference;

        public GameObject ItemPrefab => itemPrefab;
        public PlayerReference PlayerReference => _playerReference;

        public List<StatsModifier> GiveModifiers()
        {
            return _modifiers.Select(modifier => modifier.StatsModifier.GetClone(modifier.Amount, modifier.Weight, modifier.StatToModify)).ToList();
        }
    }
}
