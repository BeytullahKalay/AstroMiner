using UnityEngine;

public class CollectibleRock : Rock
{
    private RockMaterial _rockMaterial;
    protected RockType _type;

    public override void Start()
    {
        base.Start();
        _rockMaterial = GameManager.Instance.GetMaterial(_type);
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
        for (int i = 0; i < spawnAmount; i++)
        {
            var obj = Instantiate(spawnObject, transform.position, Quaternion.identity);
            var objRb = obj.GetComponent<Rigidbody2D>();
            objRb.AddRelativeForce(Random.onUnitSphere * 5,ForceMode2D.Impulse);
        }
    }
}
