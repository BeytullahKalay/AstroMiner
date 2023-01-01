using UnityEngine;

namespace Bullet
{
    public class BulletRelease : MonoBehaviour
    {
        private bool _released;

        private void OnEnable()
        {
            _released = false;
            Invoke(nameof(ReleaseBullet), BulletPooler.Instance.releaseTime);
        }
        
        public void ReleaseBullet()
        {
            if (_released) return;
            
            _released = true;
            
            BulletPooler.Instance.BulletGameObjectPool.Release(gameObject);
        }
    }
}
