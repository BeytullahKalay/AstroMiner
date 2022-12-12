using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldTile {
    public Vector3Int LocalPlace { get; set; }

    public Vector3 WorldLocation { get; set; }

    public TileBase TileBase { get; set; }

    public Tilemap TilemapMember { get; set; }

    public string Name { get; set; }
    
    public Rock RockType { get; set; }
    
    public int Health { get; set; }
}