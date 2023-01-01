using UnityEngine;

namespace Bullet
{
    [RequireComponent(typeof(BulletMove))]
    [RequireComponent(typeof(BulletDetectEnemy))]
    [RequireComponent(typeof(BulletHitEnemy))]
    [RequireComponent(typeof(BulletRelease))]
    public class BulletManager : MonoBehaviour
    {
        private BulletMove _bulletMove;
        private BulletDetectEnemy _bulletDetectEnemy;
        private BulletHitEnemy _bulletHitEnemy;
        private BulletRelease _bulletRelease;

        private void Awake()
        {
            _bulletMove = GetComponent<BulletMove>();
            _bulletDetectEnemy = GetComponent<BulletDetectEnemy>();
            _bulletHitEnemy = GetComponent<BulletHitEnemy>();
            _bulletRelease = GetComponent<BulletRelease>();
        }

        private void Update()
        {
            _bulletHitEnemy.HitEnemy(_bulletDetectEnemy.DetectEnemy(), _bulletRelease.ReleaseBullet);
        }

        private void FixedUpdate()
        {
            _bulletMove.Move();
        }
    }
}