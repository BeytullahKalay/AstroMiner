using SCOB.RockTypeHolder;
using SCOB.TileSpriteHolder;
using SCOB.UISpriteDecider;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

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

    #endregion
   

    [SerializeField] private RockTypeHolder rockTypeHolder;
    [SerializeField] private TileSpriteHolder tileSpriteHolder;
    [SerializeField] private UISpriteHolder uiSpriteHolder;

    public RockMaterial GetMaterial(RockType rockType)
    {
        return rockTypeHolder.GetRockMaterial(rockType);
    }

    public TileSpriteHolder GetTileSpriteHolder()
    {
        return tileSpriteHolder;
    }

    public UISpriteHolder GetUISpriteHolder()
    {
        return uiSpriteHolder;
    }
}
