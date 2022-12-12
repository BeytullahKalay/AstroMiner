using UnityEngine;
using System;

public abstract class Rock : MonoBehaviour
{
    [SerializeField] private int rockHealth = 100;

    public void GetHit(int damage, Vector3 rockPosition, Action destroyAction)
    {
        DecreaseRockHealth(damage);
        CheckRockIsBreak(rockPosition,destroyAction);
    }

    private void DecreaseRockHealth(int damage)
    {
        rockHealth -= damage;
    }

    private void CheckRockIsBreak(Vector3 rockPosition,Action destroyAction)
    {
        if (rockHealth <= 0)
        {
            //_rockFog.OpenFogAround(GetComponent<RockPositioning>().GetGridPosition());
            //DestroyRock(transform.position);
            OnDestroyRock(rockPosition);
            destroyAction?.Invoke();
        }
    }

    protected virtual void OnDestroyRock(Vector3 spawnObjectPosition)
    {
        Debug.Log("Destroyed");
    }
}
