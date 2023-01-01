using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        [SerializeField] private float destroyAfterSeconds = 4f;

        private EnemyAnimationController _enemyAnimationController;

        private Collider2D _collider2D;

        private void Awake()
        {
            _collider2D = GetComponent<BoxCollider2D>();
            _enemyAnimationController = GetComponentInParent<EnemyAnimationController>();
        }

        public void GetHit(int damage)
        {
            health -= damage;
            CheckHealth();
        }

        private void CheckHealth()
        {
            if (health <= 0)
            {
                _collider2D.enabled = false;
                _enemyAnimationController.PlayDeadAnim();
                _enemyAnimationController.TriggerAction(() => { Destroy(transform.parent.gameObject, destroyAfterSeconds); });
            }
        }
    }
}