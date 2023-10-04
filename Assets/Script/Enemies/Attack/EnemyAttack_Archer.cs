using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyAttack_Archer : EnemyAttack
    {
        public override void Attack()
        {
            if (!CanAttack)
                return;
            
            Debug.Log(name + " : Pan !");
            StartAttackCooldown();
        }
    }
}
