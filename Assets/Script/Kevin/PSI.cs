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

        public int GetDamage => _stats.DamageAlterable.CalculateValue(); // Il faudrait calculer que lorsque un nouveau modifier est ajoute et stocker la valeur a jour pour eviter de devoir recalculer la valeur tout le temps.
        
        ISet<PlayerStats> RealRef => _ref;

        void Awake()
        {
            RealRef.Set(_stats);
        }
    }
}