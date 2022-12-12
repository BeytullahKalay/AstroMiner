using UnityEngine;

public class CollectibleRock : Rock
{
    private RockMaterial _rockMaterial;
    protected RockType _type;

    public virtual void Start()
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
            var obj = Instantiate(spawnObject, spawnPosition, Quaternion.identity);
            var objRb = obj.GetComponent<Rigidbody2D>();
            objRb.AddRelativeForce(Random.onUnitSphere * 5, ForceMode2D.Impulse);
        }
    }
}