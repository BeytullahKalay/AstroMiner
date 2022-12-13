using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RockFog
{
    private Vector3Int _tilePos;

    private Tilemap _tilemap;

    private Tile _tile;

    public RockFog(Vector3Int tilePos, Tilemap tilemap, Tile tile)

    {
        _tilePos = tilePos;
        _tilemap = tilemap;
        _tile = tile;
    }


    public void OpenFogAround(Dictionary<Vector3Int, WorldTile> tiles)
    {
        OpenFog(tiles,new Vector3Int(1, 0, 0)); // right
        OpenFog(tiles,new Vector3Int(-1, 0, 0)); // left
        OpenFog(tiles,new Vector3Int(0, 1, 0)); // up
        OpenFog(tiles,new Vector3Int(0, -1, 0)); // down
    }

    private void OpenFog(Dictionary<Vector3Int, WorldTile> tiles ,Vector3Int pos)
    {
        var checkPosition = _tilePos + pos;
        if (_tilemap.HasTile(checkPosition) && tiles[checkPosition].RockFog._tile != null)
        {
            _tilemap.SetTile(checkPosition,tiles[checkPosition].RockFog._tile);
        }
    }
}