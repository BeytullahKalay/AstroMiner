using UnityEngine;

namespace Enemy
{
    public class EnemyFlip : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void CheckFlip(float direction)
        {
            spriteRenderer.flipX = direction < 0 ? true : false;
        }
    }
}
