using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Enemy Data")]
    public class EnemyDataSO : ScriptableObject
    {
        [SerializeField] private string enemyName;
        [SerializeField] private int enemyHealth;
        [SerializeField] private float enemySpeed;
        [SerializeField] private float enemyDamage;
        [SerializeField] private float enemyFireRate; 
        //[SerializeField] private AttackType enemyType; // Guerrier, Mage, Archer, Corentin, Assassin, Sorceleur...
    }
}
