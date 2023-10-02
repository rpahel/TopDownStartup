using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "ListScriptable")]
    [System.Serializable]
    public class ListScriptable : ScriptableObject
    {
        [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
    }
}
