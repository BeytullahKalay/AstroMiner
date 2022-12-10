using TMPro;
using UnityEngine;

public abstract class Rock : MonoBehaviour
{
    [SerializeField] private RockFog rockFog;
    [SerializeField] private Sprite rockSprite;
    [SerializeField] private int rockHealth = 100;

    private GridPosition _gridPosition;
    

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = rockSprite;
    }

    public void GetHit(int damage)
    {
        Debug.Log("Rock get hit!!");
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
            rockFog.OpenFogAround(_gridPosition);
            DestroyRock();
        }
    }

    public virtual void DestroyRock()
    {
        Debug.Log("Rock Broke");
        
        Destroy(gameObject);
    }

    public void SetGridPosition(int x, int y)
    {
        _gridPosition = new GridPosition(x, y);
    }
}
