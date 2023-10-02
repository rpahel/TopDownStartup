using UnityEngine;

namespace Game
{
    public interface IInitialisable
    {
        public PoolSystem Pool { get; set; }
        public void Initialize(Vector2 spawnPos);
        public void Disable();
    }
}
