using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerRockInteract : MonoBehaviour
{
    [SerializeField] private int damageToRock = 60;
    [SerializeField] private float hitAmountInOneSecond;
    [SerializeField] private float hitDistance = 1;
    [SerializeField] private float bounceBackForce = 2f;
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private LayerMask whatIsRock;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Tilemap tilemap;

    private Dictionary<Vector3Int, WorldTile> _tiles;

    private float _nextInteractTime;


    private void Start()
    {
        _nextInteractTime = float.MinValue;
        _tiles = GameTiles.instance.tiles;
    }

    public void Interact(Vector2 movementVector2)
    {
        if (Time.time <= _nextInteractTime) return;

        Debug.DrawRay(raycastPoint.position, movementVector2, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, movementVector2, hitDistance, whatIsRock);

        OnHitARock(movementVector2, hit);
    }

    private void OnHitARock(Vector2 movementVector2, RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            var rayPosition = hit.point;
            Vector3Int tilePos = tilemap.WorldToCell(rayPosition);


            IsHit(movementVector2, tilePos);
        }
    }

    private void IsHit(Vector2 movementVector2, Vector3Int tilePos)
    {
        if (tilemap.GetTile(tilePos))
        {
            HitActions(movementVector2, tilePos);
        }
        else if (tilemap.GetTile(tilePos - new Vector3Int(1, 0, 0)))
        {
            tilePos -= new Vector3Int(1, 0, 0);
            HitActions(movementVector2, tilePos);
        }
        else if (tilemap.GetTile(tilePos - new Vector3Int(0, 1, 0)))
        {
            tilePos -= new Vector3Int(0, 1, 0);
            HitActions(movementVector2, tilePos);
        }
        else
        {
            Debug.LogError("Tile no found!");
        }
    }

    private void HitActions(Vector2 movementVector2, Vector3Int tilePos)
    {
        HitTile(tilePos);
        AddBounceBackForce(movementVector2);
        CalculateNextHitTime();
    }

    private void HitTile(Vector3Int tilePos)
    {
        var worldLocation = _tiles[tilePos].WorldLocation;
        _tiles[tilePos].RockType.GetHit(damageToRock, worldLocation, () => DestroyTile(tilePos));
    }

    private void CalculateNextHitTime()
    {
        _nextInteractTime = Time.time + 1 / hitAmountInOneSecond;
    }

    private void AddBounceBackForce(Vector2 movementVector2)
    {
        Vector2 direction = movementVector2.normalized;
        _rb.AddForce(-direction * bounceBackForce, ForceMode2D.Impulse);
    }

    private void DestroyTile(Vector3Int tilePos)
    {
        tilemap.SetTile(tilePos, null);
    }
}