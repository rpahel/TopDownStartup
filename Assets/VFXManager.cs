using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class VFXManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _hitParticles;
        
        private ParticleSystemStopBehavior _stopBehavior = ParticleSystemStopBehavior.StopEmitting;

        public static VFXManager Instance => _instance;
        private static VFXManager _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                _instance = this;
            }
            else
            {
                throw new ArgumentNullException(name + " There is more than one instance of VFXManager");
            }
            
        }

        public void HitVFX(Transform position)
        {
            _hitParticles.transform.position = position.position;
            _hitParticles.Play();
        }
    }
}
