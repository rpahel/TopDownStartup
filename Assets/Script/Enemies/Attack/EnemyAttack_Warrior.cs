using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyAttack_Warrior : EnemyAttack
    {
        public override void Attack()
        {
            if (!CanAttack)
                return;
            
            Debug.Log(name + " : Pow !");
            StartAttackCooldown();
        }
    }
}
