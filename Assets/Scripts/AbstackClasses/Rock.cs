using UnityEngine;

public abstract class Rock : MonoBehaviour
{
    [SerializeField] private int rockHealth = 100;

    private RockFog _rockFog;


    public virtual void Start()
    {
        _rockFog = GetComponent<RockFog>();
    }

    public void GetHit(int damage)
    {
        DecreaseRockHealth(damage);
        CheckRockIsBreak();
    }

    private void DecreaseRockHealth(int damage)
    {
        rockHealth -= damage;
    }

    private void CheckRockIsBreak()
    {
        if (rockHealth <= 0)
        {
            _rockFog.OpenFogAround(GetComponent<RockPositioning>().GetGridPosition());
            DestroyRock();
        }
    }

    protected virtual void DestroyRock()
    {
        Destroy(gameObject);
    }



    private void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
