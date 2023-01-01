using UnityEngine;

namespace Bullet
{
    public class BulletMove : MonoBehaviour
    {
        [SerializeField] private float bulletMoveSpeed = 20f;
        
        public void Move()
        {
            transform.Translate(Vector3.up * (bulletMoveSpeed * Time.fixedDeltaTime));
        }
        
    }
}
