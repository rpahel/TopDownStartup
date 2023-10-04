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
        private Alterable<float> _fireRateAlterable;

        public Alterable<float> FireRateAlterable => _fireRateAlterable ??= new Alterable<float>(_baseFireRate);
        public Health Health => _health;


        public PlayerStats GetClone()
        {
            var t = ScriptableObject.CreateInstance<PlayerStats>();

            t._baseFireRate = _baseFireRate;
            t._health = _health;
            return t;
        }
    }
}
