using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class VFXManager : MonoBehaviour
    {
        [FormerlySerializedAs("_hitParticles")] [SerializeField] private ParticleSystem _deathParticles;
        
        private ParticleSystemStopBehavior _stopBehavior = ParticleSystemStopBehavior.StopEmitting;

        public static VFXManager Instance => _instance;
        private static VFXManager _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                throw new ArgumentNullException(name + " There is more than one instance of VFXManager");
            }
            
        }

        public void DeathVFX(Transform position)
        {
            _deathParticles.transform.position = position.position;
            _deathParticles.Play();
        }
    }
}
