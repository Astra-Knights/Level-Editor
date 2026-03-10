using UnityEngine;

public class GridCell
{
    public int x;
    public int z;

    public GameObject block;

    public GridCell(int x, int z)
    {
        this.x = x;
        this.z = z;
        block = null;
    }

    public bool IsEmpty()
    {
        return block == null;
    }
}