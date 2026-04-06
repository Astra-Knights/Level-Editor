using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField]
    private int width = 10;

    [SerializeField]
    private int height = 5;

    [SerializeField]
    private float cellSize = 5f;

    private GridCell[,] grid;

    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        grid = new GridCell[width, height];

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int z = 0; z < grid.GetLength(1); z++)
            {
                grid[x, z] = new GridCell(x, z);
            }
        }
    }

    public void PlaceBlock(GameObject prefab, int x, int z)
    {
        if (x < 0 || x >= width || z < 0 || z >= height) return;

        GridCell cell = grid[x, z];

        if (!cell.IsEmpty()) return;

        Vector3 pos = GridToWorld(x, z);
        GameObject block = Instantiate(prefab, pos, Quaternion.identity, transform);

        cell.block = block;
    }

    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt(worldPos.x / cellSize);
        int z = Mathf.FloorToInt(worldPos.z / cellSize);

        return new Vector2Int(x, z);
    }

    public Vector3 GridToWorld(int x, int z)
    {
        return new Vector3(x * cellSize + cellSize * 0.5f, 0, z * cellSize + cellSize * 0.5f);
    }
}