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
        PlayHitEffect(tile);
    }

    private void PlayHitEffect(WorldTile tile)
    {
        Color c = tile.TilemapMember.color;
        c.a = .5f;
        float t = 0;
        DOTween.To(() => t, x => t = x, 1, _hitFadeDuration).OnStart(() =>
        {
            tile.TilemapMember.SetColor(tile.LocalPlace, c);
        }).OnComplete(() =>
        {
            c.a = 1;
            tile.TilemapMember.SetColor(tile.LocalPlace, c);
        });
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

    public virtual Tile GetTile()
    {
        return null;
    }
}