using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Game
{
    public class PSI : MonoBehaviour, IDamager
    {
        [SerializeField] PlayerStats _stats;
        [SerializeField] PlayerStatsReference _ref;

        public int GetDamage => _stats.Damage;
        
        ISet<PlayerStats> RealRef => _ref;

        public IReadOnlyList<int> T { get => t; }

        List<int> t;

        void Awake()
        {
            //_ref.Set(_e);
            RealRef.Set(_stats);
        }
    }
}