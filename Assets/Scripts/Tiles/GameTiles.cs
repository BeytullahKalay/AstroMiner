using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTiles : MonoBehaviour {
	
	
	public static GameTiles instance;
	
	public Tilemap ColliderTilemap;
	public Tilemap CoverTilemap;

	public Dictionary<Vector3Int, WorldTile> Tiles;

	[SerializeField] private RockTypePicker rockTypePicker;

	private void Awake() 
	{
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		GetWorldTiles();
	}

	// Use this for initialization
	private void GetWorldTiles ()
	{
		Tiles = new Dictionary<Vector3Int, WorldTile>();
		foreach (Vector3Int pos in ColliderTilemap.cellBounds.allPositionsWithin)
		{
			var localPlace = new Vector3Int(pos.x, pos.y, pos.z);
			var selectRockType = rockTypePicker.SelectRockType();
			
			selectRockType.Start(); // initialize rock for make tiles gettable

			if (!ColliderTilemap.HasTile(localPlace)) continue;
			var tile = new WorldTile
			{
				LocalPlace = localPlace,
				WorldLocation = ColliderTilemap.CellToWorld(localPlace),
				TileBase = ColliderTilemap.GetTile(localPlace),
				TilemapMember = ColliderTilemap,
				Name = localPlace.x + "," + localPlace.y,
				Rock = selectRockType,
				Health = 100,
				RockFog = new RockFog(localPlace,CoverTilemap,selectRockType.GetTile()),
			};
			Tiles.Add(tile.LocalPlace, tile);
		}
	}
}