using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyDetectWall))]
    [RequireComponent(typeof(EnemyStateController))]
    public class EnemyManager : MonoBehaviour
    {
        private EnemyMovement _enemyMovement;
        private EnemyDetectWall _enemyDetectWall;
        private EnemyStateController _enemyStateController;
        

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyDetectWall = GetComponent<EnemyDetectWall>();
            _enemyStateController = GetComponent<EnemyStateController>();
        }

        private void Update()
        {
            _enemyDetectWall.SetDetectPosition(_enemyMovement.Direction);
            _enemyStateController.SetStateToAttack(_enemyDetectWall.IsBaseDetected());
        }

        private void FixedUpdate()
        {
            _enemyMovement.Move(_enemyStateController.EnemyState);
        }
    }
}
