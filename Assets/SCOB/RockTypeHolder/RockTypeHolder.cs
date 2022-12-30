using System.Collections.Generic;
using UnityEngine;

namespace SCOB.RockTypeHolder
{
    [CreateAssetMenu(fileName = "RockType",menuName = "ScriptableObjects/RockTypeHolder")]
    public class RockTypeHolder : ScriptableObject
    {
        public List<RockMaterial> Materials = new List<RockMaterial>();

        public RockMaterial GetRockMaterial(RockType rockType)
        {
            foreach (var rockMaterial in Materials)
            {
                if (rockMaterial.RockType == rockType)
                {
                    return rockMaterial;
                }
            }

            return Materials[0];
        }
    }

    [System.Serializable]
    public struct RockMaterial
    {
        public RockType RockType;
        public Sprite RockSprite;
        public GameObject ObjectToSpawn;
        public Vector2Int spawnAmountMinMax;

    }


    public enum RockType
    {
        Empty,
        Blue,
        Yellow
    }
}