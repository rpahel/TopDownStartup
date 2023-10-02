using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IHealth
    {
        public void TakeDamage(int damage);
        public void Regen(int amount);
        public void Die();
    }
}
