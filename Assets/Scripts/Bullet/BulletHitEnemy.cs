using System;
using Enemy;
using UnityEngine;

namespace Bullet
{
    public class BulletHitEnemy : MonoBehaviour
    {
        [SerializeField] private int damage = 25;

        public void HitEnemy(Collider2D enemyCollider,Action releaseAction)
        {
            if (enemyCollider)
            {
                enemyCollider.gameObject.GetComponent<EnemyHealth>().GetHit(damage);
                releaseAction?.Invoke();
            }
        }
    }
}
