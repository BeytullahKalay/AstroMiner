using SCOB.RockTypeHolder;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AbstractClasses
{
    public abstract class CollectibleRockTile : Rock
    {
        private RockMaterial _rockMaterial;
        protected RockType _type;
        protected Tile _tile;

    
        public override void Start()
        {
            _rockMaterial = GameManager.Instance.GetMaterial(_type);
        }

        protected override void OnDestroyRock(Vector3 spawnObjectPosition)
        {
            var range = _rockMaterial.spawnAmountMinMax;
            SpawnObject(_rockMaterial.ObjectToSpawn, spawnObjectPosition, Random.Range(range.x, range.y + 1));
            base.OnDestroyRock(spawnObjectPosition);
        }

        private void SpawnObject(GameObject spawnObject, Vector3 spawnPosition, int spawnAmount)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Instantiate(spawnObject, spawnPosition, Quaternion.identity);
            }
        }
    
        public override Tile GetTile()
        {
            return _tile;
        }
    }
}