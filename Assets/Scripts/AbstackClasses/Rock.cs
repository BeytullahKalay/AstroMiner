using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public abstract class Rock : MonoBehaviour
{
    [SerializeField] private int rockHealth = 100;

    public virtual void Start()
    {
        
    }


    public void GetHit(int damage, WorldTile tile, Action destroyAction)
    {
        DecreaseRockHealth(damage);
        CheckRockIsBreak(tile.WorldLocation, tile, destroyAction);
    }

    private void DecreaseRockHealth(int damage)
    {
        rockHealth -= damage;
    }

    private void CheckRockIsBreak(Vector3 rockPosition, WorldTile tile, Action destroyAction)
    {
        if (rockHealth <= 0)
        {
            tile.RockFog.OpenFogAround(GameTiles.instance.tiles);
            OnDestroyRock(rockPosition);
            destroyAction?.Invoke();
        }
    }

    protected virtual void OnDestroyRock(Vector3 spawnObjectPosition)
    {
    }

    public virtual Tile GetTile()
    {
        return null;
    }
}