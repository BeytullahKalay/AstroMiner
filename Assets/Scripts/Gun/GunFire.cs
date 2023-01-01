using Bullet;
using Player;
using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(BulletPooler))]
    public class GunFire : MonoBehaviour
    {
        [SerializeField] private float fireAmountInOneSeconds = .5f;

        private float _lastFireTime = float.MinValue;

        public void FireGun(KeyCode key)
        {
            if (Time.time < _lastFireTime) return;

            if (PlayerStateController.Instance.CurrentPlayerState != PlayerStateController.PlayerState.Interact) return;

            if (Input.GetKey(key))
            {
                BulletPooler.Instance.BulletGameObjectPool.Get();

                _lastFireTime = Time.time + 1 / fireAmountInOneSeconds;
            }
        }
    }
}