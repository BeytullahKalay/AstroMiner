using Player;
using UnityEngine;

namespace Gun
{
    public class GunFire : MonoBehaviour
    {
        [SerializeField] private float fireAmountInOneSeconds = .5f;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bullet;

        private float _lastFireTime = float.MinValue;

        public void FireGun(KeyCode key)
        {
            if (Time.time < _lastFireTime) return;

            if (PlayerStateController.Instance.CurrentPlayerState != PlayerStateController.PlayerState.Interact) return;

            if (Input.GetKey(key))
            {
                Debug.Log("Fire!!");

                Instantiate(bullet, firePoint.position, firePoint.rotation);

                _lastFireTime = Time.time + 1 / fireAmountInOneSeconds;
            }
        }
    }
}