using UnityEngine;

namespace Enemy
{
    public class EnemyStateController : MonoBehaviour
    {
        public EnemyState EnemyState { get; private set; }

        public void SetStateToAttack(bool onBaseDetected)
        {
            if (onBaseDetected)
            {
                EnemyState = EnemyState.Attack;
            }
        }
    }
}
