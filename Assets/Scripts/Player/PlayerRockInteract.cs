using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerRockInteract : MonoBehaviour
{
    [SerializeField] private int damageToRock = 60;
    [SerializeField] private float hitAmountInOneSecond;
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
        
        RaycastHit2D hit = Physics2D.Linecast(raycastPoint.position, (Vector2)raycastPoint.position + movementVector2, whatIsRock);

        Debug.DrawLine(raycastPoint.position, (Vector2)raycastPoint.position + movementVector2, Color.red);

        OnHitARock(movementVector2, hit,(Vector2)raycastPoint.position + movementVector2);
    }

    private void OnHitARock(Vector2 movementVector2, RaycastHit2D hit,Vector3 rayEndPosition)
    {
        if (hit.collider != null)
        {
            Vector3Int tilePos = tilemap.WorldToCell(rayEndPosition);
            IsHit(movementVector2, tilePos);
        }
    }

    private void IsHit(Vector2 movementVector2, Vector3Int tilePos)
    {
        if (tilemap.GetTile(tilePos))
        {
            HitActions(movementVector2, tilePos);
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
        _tiles[tilePos].Rock.GetHit(damageToRock, _tiles[tilePos], () => DestroyTile(tilePos));
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