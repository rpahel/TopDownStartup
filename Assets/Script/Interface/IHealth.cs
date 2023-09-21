using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IHealth : IDamageable
    {
        public int Health { get; set; }
    }
}
