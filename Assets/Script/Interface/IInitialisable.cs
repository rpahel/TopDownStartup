using UnityEngine;

namespace Game
{
    public interface IInitialisable
    {
        public PoolSystem Pool { get; set; }
        public Room Room { get; set; }
        public void Initialize(Vector2 spawnPos, Transform playerTransform = null);
        public void Disable();
    }
}
