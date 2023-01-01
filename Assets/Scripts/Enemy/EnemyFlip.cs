using UnityEngine;

namespace Enemy
{
    public class EnemyFlip : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void CheckFlip(float direction)
        {
            if (direction > 0)
            {
                spriteRenderer.transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            else
            {
                spriteRenderer.transform.rotation = Quaternion.Euler(Vector3.up * 180);
            }
        }
    }
}
