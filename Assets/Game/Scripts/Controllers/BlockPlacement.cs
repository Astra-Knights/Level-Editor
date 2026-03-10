using UnityEngine;

public class BlockPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;

    private GridSystem grid;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        grid = GetComponent<GridSystem>();
    }

    private void Update()
    {
        PlaceBlock();
    }

    private void PlaceBlock()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector2Int pos = grid.WorldToGrid(hit.point);

                grid.PlaceBlock(blockPrefab, pos.x, pos.y);
            }
        }
    }
}
