using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackAmountInOneSecond = .5f;

    private float _lastAttackTime = float.MinValue;

    public void Attack(EnemyState state,Action attackAnimationAction)
    {
        if (state == EnemyState.Attack && Time.time > _lastAttackTime)
        {
            attackAnimationAction?.Invoke();
            Debug.Log("Enemy Dear Attack");
            _lastAttackTime = Time.time + 1/attackAmountInOneSecond;
        }
    }
}
