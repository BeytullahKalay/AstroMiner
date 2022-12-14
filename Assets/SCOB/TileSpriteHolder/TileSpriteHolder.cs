using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "TileSpriteType", menuName = "ScriptableObjects/TileSpriteTypeHolder")]
public class TileSpriteHolder : ScriptableObject
{
    [SerializeField] private Tile yellow;
    [SerializeField] private Tile blue;


    public Tile GetYellowRockSprite()
    {
        return yellow;
    }
    
    public Tile GetBlueRockSprite()
    {
        return blue;
    }
}