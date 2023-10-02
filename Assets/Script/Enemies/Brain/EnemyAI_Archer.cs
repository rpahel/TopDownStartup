using UnityEngine;

namespace Game
{
    public class EnemyAI_Archer : EnemyAI
    {
        private void FixedUpdate()
        {
            // Fuis si le joueur se rapproche trop
            if (IsPlayerInRange(NearPlayerRadius))
            {
                Enemy.GetMovement.ContinuousMove(-EnemyToPlayer);
            }
        }
    }
}
