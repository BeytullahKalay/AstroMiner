using UnityEngine;

public class RockFog : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fogSpriteRenderer;

    private GridSystem _gridSystem;
    
    private void Start()
    {
        _gridSystem = GridSystem.Instance;
    }

    public void OpenFogAround(GridPosition gridPosition)
    {
        // Right grid
        if (gridPosition.x < _gridSystem.GetTotalWidth() - 1 && _gridSystem.GetRockFromGrid(gridPosition.RightGrid()))
        {
            _gridSystem.GetRockFromGrid(gridPosition.RightGrid()).GetComponent<RockFog>().OpenSelfFog();
        }

        // Left grid
        if (gridPosition.x > 0 && _gridSystem.GetRockFromGrid(gridPosition.LeftGrid()))
        {
            _gridSystem.GetRockFromGrid(gridPosition.LeftGrid()).GetComponent<RockFog>().OpenSelfFog();
        }

        // Up grid
        if (gridPosition.y - 1 >= 0 && _gridSystem.GetRockFromGrid(gridPosition.UpGrid()))
        {
            _gridSystem.GetRockFromGrid(gridPosition.UpGrid()).GetComponent<RockFog>().OpenSelfFog();
        }

        // Down grid
        if (gridPosition.y < _gridSystem.GetTotalHeight() - 1 && _gridSystem.GetRockFromGrid(gridPosition.DownGrid()))
        {
            _gridSystem.GetRockFromGrid(gridPosition.DownGrid()).GetComponent<RockFog>().OpenSelfFog();
        }
    }

    private void OpenSelfFog()
    {
        Color c = fogSpriteRenderer.material.color;
        c.a = 0;
        fogSpriteRenderer.material.color = c;
    }

    private void OnDestroy()
    {
        Destroy(fogSpriteRenderer.material);
    }
}