using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Item")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private GameObject itemPrefab;
        public GameObject ItemPrefab => itemPrefab;

        [SerializeField] private List<StatsModifier> _modifiers = new List<StatsModifier>();

    }
}
