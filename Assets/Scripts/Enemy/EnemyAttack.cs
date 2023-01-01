using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackAmountInOneSecond = .5f;

    private float _lastAttackTime = float.MinValue;

    public void Attack(EnemyState state)
    {
        if (state == EnemyState.Attack && Time.time > _lastAttackTime)
        {
            Debug.Log("Enemy Attack");
            _lastAttackTime = Time.time + 1/attackAmountInOneSecond;
        }
    }
}
