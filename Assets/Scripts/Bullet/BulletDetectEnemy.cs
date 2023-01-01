using UnityEngine;

namespace Bullet
{
    public class BulletDetectEnemy : MonoBehaviour
    {
        [SerializeField] private float detectHitRadius = .5f;
        [SerializeField] private LayerMask whatIsEnemy;

        public Collider2D DetectEnemy()
        {
            return Physics2D.OverlapCircle(transform.position, detectHitRadius, whatIsEnemy);
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, detectHitRadius);
        }
    }
}