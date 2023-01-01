using UnityEngine;
using UnityEngine.Pool;

namespace Bullet
{
    public class BulletPooler : MonoBehaviour
    {
        public ObjectPool<GameObject> BulletGameObjectPool;
        public float releaseTime = 5f;

        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform firePoint;

        [SerializeField] private int defaultCapacity = 100;
        [SerializeField] private int maxSize = 500;

        public static BulletPooler Instance;

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

        private void Start()
        {
            InitializeBulletPool();
        }

        private void InitializeBulletPool()
        {
            BulletGameObjectPool = new ObjectPool<GameObject>(
                () => Instantiate(bullet, firePoint.position, firePoint.rotation),
                poolBullet =>
                {
                    poolBullet.SetActive(true);
                    poolBullet.transform.position = firePoint.position;
                    poolBullet.transform.rotation = firePoint.rotation;
                }, 
                poolBullet =>
                { poolBullet.SetActive(false); },
                poolBullet => 
                { Destroy(poolBullet); }, 
                true, defaultCapacity, maxSize
            );
        }
    }
}