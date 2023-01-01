using Enemy;
using UnityEngine;

namespace Bullet
{
    public class BulletHit : MonoBehaviour
    {
        [SerializeField] private float detectHitRadius = .5f;
        [SerializeField] private LayerMask whatIsEnemy;
        [SerializeField] private int damage = 25;

        private void Update()
        {
            var enemyCollider = Physics2D.OverlapCircle(transform.position, detectHitRadius, whatIsEnemy);

            if (enemyCollider)
            {
                Debug.Log("enemy hit");
                enemyCollider.gameObject.GetComponent<EnemyHealth>().GetHit(damage);
                Destroy(gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, detectHitRadius);
        }
    }
}
