using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float moveSpeed = 2f;

        public float Direction { get;private set; }
        
        public void Move(EnemyState enemyState)
        {
            if (enemyState != EnemyState.Move) return;
            
            Direction = (target.position - transform.position).normalized.x;
            transform.Translate(Vector2.right * (Direction * (Time.fixedDeltaTime * moveSpeed)));
        }
    }
}