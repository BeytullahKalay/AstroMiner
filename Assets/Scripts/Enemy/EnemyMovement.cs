using Capsule;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2f;

        public float Direction { get; private set; }

        public void Move(EnemyState enemyState)
        {
            if (enemyState != EnemyState.Move) return;

            Direction = (CapsuleHealth.Instance.gameObject.transform.position - transform.position).normalized.x;
            transform.Translate(Vector2.right * (Direction * (Time.fixedDeltaTime * moveSpeed)));
        }
    }
}