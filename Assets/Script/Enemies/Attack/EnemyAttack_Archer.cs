using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
    public class EnemyAttack_Archer : EnemyAttack
    {
        private PoolSystem _bulletPool;

        private void Start()
        {
            _bulletPool = FindObjectsOfType<PoolSystem>().First(i => i.name == "PoolBullet");
        }
        
        public override void Attack()
        {
            if (!CanAttack)
                return;
            
            if(FireBullet())
                StartAttackCooldown();
        }

        private bool FireBullet()
        {
            if(!_bulletPool)
                return false;
            
            Bullet bullet = _bulletPool.GetObject() as Bullet;

            if (!bullet)
                return false;

            if (Enemy)
                bullet.Initialize(base.Enemy.GetBrain.PlayerTransform.position, this.transform);

            return true;
        }
    }
}
