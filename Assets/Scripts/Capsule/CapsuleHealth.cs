using UnityEngine;

namespace Capsule
{
    public class CapsuleHealth : MonoBehaviour
    {
        [SerializeField] private int health = 100;

        #region Singleton

        public static CapsuleHealth Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
        
        
        
        public void TakeDamage(int damageTaken)
        {
            health -= damageTaken;
            CheckCapsuleHealth();
        }

        private void CheckCapsuleHealth()
        {
            if (health <= 0)
            {
                Debug.Log("Game Over");
                // TODO: open game over UI panel
            }
        }
    }
}
