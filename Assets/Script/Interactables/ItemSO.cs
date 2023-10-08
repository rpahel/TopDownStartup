using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public struct Modifier
    {
        [SerializeField] private float _amount;
        [SerializeField] private int _weight;
        [SerializeField] private StatsModifier _modifier;
        [SerializeField] private Stat _statToModify;

        public Modifier(float amount, int weight, StatsModifier mod, Stat stat)
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

    [System.Serializable]
    [CreateAssetMenu(menuName = "Item")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private List<Modifier> _modifiers = new();

        public GameObject ItemPrefab => itemPrefab;

        public (List<StatsModifier>,List<Stat>, List<int>) GiveModifiers()
        {
            var statsModifiers = _modifiers.Select(modifier => modifier.StatsModifier.GetClone(modifier.Amount, modifier.Weight, modifier.StatToModify)).ToList();
            var stats = _modifiers.Select(stat => stat.StatToModify).ToList();
            var weights = _modifiers.Select(w => w.Weight).ToList();

            return (statsModifiers, stats, weights);
        }
    }
}
