namespace Game
{
    public class EnemyAI_Warrior : EnemyAI
    {
        private void FixedUpdate()
        {
            // Fonce vers le joueur des qu'il le detecte
            if (IsPlayerInRange(DetectionRadius))
            {
                Enemy.GetMovement.ContinuousMove(EnemyToPlayer);
            }
        }
    }
}
