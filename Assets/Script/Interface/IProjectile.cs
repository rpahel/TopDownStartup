using System.Collections;
using System.Collections.Generic;
using Codice.CM.Client.Differences;
using UnityEngine;

namespace Game
{
    public interface IProjectile
    {
        public void Move();
        public void Hit();

    }
}
