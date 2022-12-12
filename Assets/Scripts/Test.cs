using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;


    // private void Update()
    // {
    //     Vector3Int tilePos = tilemap.WorldToCell(transform.position);
    //
    //     if (tilemap.GetTile(tilePos))
    //     {
    //         var tiles = GameTiles.instance.tiles;
    //         var worldLocation = tiles[tilePos].WorldLocation;
    //         tiles[tilePos].RockType.DestroyRock(worldLocation);
    //         tilemap.SetTile(tilePos, null);
    //     }
    // }
}