using System;
using Capsule;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackAmountInOneSecond = .5f;

    private float _lastAttackTime = float.MinValue;

    public void Attack(EnemyState state, Action attackAnimationAction)
    {
        if (state == EnemyState.Attack && Time.time > _lastAttackTime)
        {
            attackAnimationAction?.Invoke();
            CapsuleHealth.Instance.TakeDamage(damage);
            _lastAttackTime = Time.time + 1 / attackAmountInOneSecond;
        }
    }
}