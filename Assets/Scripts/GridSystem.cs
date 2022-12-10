using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static GridSystem Instance { get; private set; }
    
    [Header("Distance between rocks")]
    [SerializeField] private float distanceBetweenX;
    [SerializeField] private float distanceBetweenY;

    [Header("Level Height/Weight")]
    [SerializeField] private int height;
    [SerializeField] private int width;

    [SerializeField] private GameObject objectToSpawn;


    private GameObject[,] _grids;

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

    private void Start()
    {
        _grids = new GameObject[width * 2,height];
        CreateLevel();
    }

    private void CreateLevel()
    {
        GameObject parent = new GameObject("Rocks");
        
        for (int x = -width; x < width; x++)
        {
            for (int y = 0; y > -height; y--)
            {
                float xPosition = x * distanceBetweenX;
                float yPosition = y * distanceBetweenY;

                int gridIndexX = x + width;
                int gridIndexY = Mathf.Abs(y);
                
                // Instantiate and positioning object
                var rock = Instantiate(objectToSpawn, new Vector3(xPosition, yPosition, 0), Quaternion.identity);

                // assign position values to the rock
                rock.GetComponent<Rock>().SetGridPosition(gridIndexX, gridIndexY);
                
                // parenting
                rock.transform.SetParent(parent.transform);
                
                // assign object to grid system
                _grids[gridIndexX, gridIndexY] = rock;
            }
        }
    }

    public GameObject GetRockFromGrid(GridPosition gripPosition)
    {
        
        return _grids[gripPosition.x, gripPosition.y];
    }

    public int GetTotalWidth()
    {
        return width * 2;
    }

    public int GetTotalHeight()
    {
        return height;
    }
}