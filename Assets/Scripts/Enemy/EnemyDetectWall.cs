using UnityEngine;

namespace Enemy
{
    public class EnemyDetectWall : MonoBehaviour
    {
        [SerializeField] private Transform detectPosition;
        [SerializeField] private float radius = 1f;
        [SerializeField] private LayerMask whatIsBaseLayer;

        public void SetDetectPosition(float direction)
        {
            var pos = detectPosition.localPosition;
            pos.x = direction;
            detectPosition.localPosition = pos;
        }

        public Collider2D IsBaseDetected()
        {
            return Physics2D.OverlapCircle(detectPosition.position, radius, whatIsBaseLayer);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(detectPosition.position, radius);
        }
    }
}
