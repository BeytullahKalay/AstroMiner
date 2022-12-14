using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.Tilemaps;

public abstract class Rock : MonoBehaviour
{
    private int _rockHealth = 100;

    private float _hitFadeDuration = .05f;

    public virtual void Start()
    {
    }


    public void GetHit(int damage, WorldTile tile, Action destroyAction)
    {
        DecreaseRockHealth(damage);
        CheckRockIsBreak(tile.WorldLocation, tile, destroyAction);
        PlayHitEffect(tile,_hitFadeDuration);
    }

    private void DecreaseRockHealth(int damage)
    {
        _rockHealth -= damage;
    }

    private void CheckRockIsBreak(Vector3 rockPosition, WorldTile tile, Action destroyAction)
    {
        if (_rockHealth <= 0)
        {
            tile.RockFog.OpenFogAround(GameTiles.instance.tiles);
            OnDestroyRock(rockPosition);
            destroyAction?.Invoke();
        }
    }

    protected virtual void OnDestroyRock(Vector3 spawnObjectPosition)
    {
    }
    
    private void PlayHitEffect(WorldTile tile, float hitFadeDuration)
    {
        Color c = tile.TilemapMember.color;
        c.a = .5f; // make opacity half open
        float t = 0;
        DOTween.To(() => t, x => t = x, 1, hitFadeDuration)
            .OnStart(() =>
            {
                tile.TilemapMember.SetColor(tile.LocalPlace, c);
            })
            .OnComplete(() =>
            {
                c.a = 1;
                tile.TilemapMember.SetColor(tile.LocalPlace, c);
            });
    }

    public virtual Tile GetTile()
    {
        return null;
    }
    
    
}