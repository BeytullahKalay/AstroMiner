using UnityEngine;

public class RockPositioning : MonoBehaviour
{
    private GridPosition _gridPosition;
    
    public void SetGridPosition(int x, int y)
    {
        _gridPosition = new GridPosition(x, y);
    }

    public GridPosition GetGridPosition()
    {
        return _gridPosition;
    }
}
