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

    private void Start()
    {
        RenderGrid();
    }

    private void OnValidate()
    {
        CreateGrid();
        RenderGrid();
    }

    void CreateGrid()
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

    void RenderGrid()
    {
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }

        for (int x = 0; x <= grid.GetLength(0); x++)
        {
            Vector3 start = new Vector3(x * cellSize, 0, 0);
            Vector3 end = new Vector3(x * cellSize, 0, grid.GetLength(1) * cellSize);
            Utils.DrawLine(start, end, transform);
        }

        for (int z = 0; z <= grid.GetLength(1); z++)
        {
            Vector3 start = new Vector3(0, 0, z * cellSize);
            Vector3 end = new Vector3(grid.GetLength(0) * cellSize, 0, z * cellSize);
            Utils.DrawLine(start, end, transform);
        }
    }

    public void PlaceBlock(GameObject prefab, int x, int z)
    {
        GridCell cell = grid[x, z];

        if (!cell.IsEmpty()) return;

        Vector3 pos = GridToWorld(x, z);
        GameObject block = Instantiate(prefab, pos, Quaternion.identity);

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