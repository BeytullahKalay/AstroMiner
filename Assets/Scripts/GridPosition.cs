
public struct GridPosition
{
    public int x;
    public int y;
    public GridPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public GridPosition RightGrid()
    {
        return new GridPosition(x + 1, y);
    }

    public GridPosition LeftGrid()
    {
        return new GridPosition(x - 1, y);
    }

    public GridPosition UpGrid()
    {
        return new GridPosition(x, y - 1);
    }
    
    public GridPosition DownGrid()
    {
        return new GridPosition(x, y + 1);
    }
    
}
