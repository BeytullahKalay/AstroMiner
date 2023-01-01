using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health = 100;

        public void GetHit(int damage)
        {
            health -= damage;
            CheckHealth();
        }

        private void CheckHealth()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
