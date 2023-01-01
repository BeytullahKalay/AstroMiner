using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyDetectWall))]
    [RequireComponent(typeof(EnemyStateController))]
    [RequireComponent(typeof(EnemyAttack))]
    [RequireComponent(typeof(EnemyAnimationController))]
    [RequireComponent(typeof(EnemyFlip))]
    public class EnemyManager : MonoBehaviour
    {
        private EnemyMovement _enemyMovement;
        private EnemyDetectWall _enemyDetectWall;
        private EnemyStateController _enemyStateController;
        private EnemyAttack _enemyAttack;
        private EnemyAnimationController _enemyAnimationController;
        private EnemyFlip _enemyFlip;
        

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyDetectWall = GetComponent<EnemyDetectWall>();
            _enemyStateController = GetComponent<EnemyStateController>();
            _enemyAttack = GetComponent<EnemyAttack>();
            _enemyAnimationController = GetComponent<EnemyAnimationController>();
            _enemyFlip = GetComponent<EnemyFlip>();
        }

        private void Update()
        {
            _enemyDetectWall.SetDetectPosition(_enemyMovement.Direction);
            _enemyStateController.SetStateToAttack(_enemyDetectWall.IsBaseDetected());
            _enemyAttack.Attack(_enemyStateController.EnemyState,_enemyAnimationController.PlayAttackAnim);
            _enemyFlip.CheckFlip(_enemyMovement.Direction);
        }

        private void FixedUpdate()
        {
            _enemyMovement.Move(_enemyStateController.EnemyState);
        }
    }
}
