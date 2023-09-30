using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Enemy Data")]
    public class EnemyDataSO : ScriptableObject
    {
        //== Fields ================================================
        [SerializeField] private int _enemyHealth;
        [SerializeField] private float _enemySpeed;
        [SerializeField] private int _enemyDamage;
        [SerializeField] private float _enemyFireRate; 
        [SerializeField] private AttackType _enemyType; // Guerrier, Mage, Archer, Corentin, Assassin, Sorceleur...
        
        //== Properties ============================================
        public string GetName() => _enemyType.ToString();
        public int GetHealth() => _enemyHealth;
        public float GetSpeed() => _enemySpeed;
        public int GetDamage() => _enemyDamage;
        public float GetFireRate() => _enemyFireRate;
        public AttackType GetAttackType() => _enemyType;
    }
}
