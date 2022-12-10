using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private RockTypeHolder rockTypeHolder;

    public RockMaterial GetMaterial(RockType rockType)
    {
        return rockTypeHolder.GetRockMaterial(rockType);
    }
}
