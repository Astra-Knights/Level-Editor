using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField]
    private int width = 10;

    [SerializeField]
    private int height = 5;

    [SerializeField]
    private float cellSize = 5f;

    private void Start()
    {
        RenderGrid();
    }

    private void OnValidate()
    {
        RenderGrid();
    }

    void RenderGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int x = 0; x <= width; x++)
        {
            Vector3 start = new Vector3(x * cellSize, 0, 0);
            Vector3 end = new Vector3(x * cellSize, 0, height * cellSize);
            Utils.DrawLine(start, end, transform);
        }

        for (int z = 0; z <= height; z++)
        {
            Vector3 start = new Vector3(0, 0, z * cellSize);
            Vector3 end = new Vector3(width * cellSize, 0, z * cellSize);
            Utils.DrawLine(start, end, transform);
        }
    }
}
