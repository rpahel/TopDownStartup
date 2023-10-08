using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Player Stats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private float _baseFireRate;
        [SerializeField] private Health _health;
        [SerializeField] private int _baseDamage;

        private Alterable<float> _fireRateAlterable;
        private Alterable<int> _damageAlterable;

        public Alterable<float> FireRateAlterable => _fireRateAlterable ??= new Alterable<float>(_baseFireRate);
        public Alterable<int> DamageAlterable => _damageAlterable ??= new Alterable<int>(_baseDamage);

        public Health Health => _health;
    }
}
