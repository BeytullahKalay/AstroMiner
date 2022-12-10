using UnityEngine;

public class BlueRock : Rock
{
    private RockMaterial _rockMaterial;

    public override void Start()
    {
        base.Start();
        _rockMaterial = GameManager.Instance.GetMaterial(RockType.Blue);
        GetComponent<SpriteRenderer>().sprite = _rockMaterial.RockSprite;
    }

    protected override void DestroyRock()
    {
        var range = _rockMaterial.spawnAmountMinMax;
        SpawnObject(_rockMaterial.ObjectToSpawn, Random.Range(range.x, range.y + 1));
        base.DestroyRock();
    }

    private void SpawnObject(GameObject spawnObject, int spawnAmount)
    {
        Debug.Log("Object Spawned");
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(spawnObject, transform.position, Quaternion.identity);
        }
    }
}