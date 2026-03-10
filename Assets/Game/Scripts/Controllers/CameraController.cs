using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float panSpeed = 10f;

    [SerializeField]
    private float zoomSpeed = 5f;

    [SerializeField]
    private float minZoom = 12f;

    [SerializeField]
    private float maxZoom = 24f;

    [SerializeField]
    private GameObject block;

    private Vector3 lastMousePos;
    private float zoomTargetY;

    private void Start()
    {
        zoomTargetY = transform.position.y;
    }

    private void Update()
    {
        HandleMove();
        HandleZoom();
    }

    private void HandleMove()
    {
        if (Input.GetMouseButtonDown(1))
            lastMousePos = Input.mousePosition;

        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastMousePos;
            Vector3 move = new Vector3(-delta.x, 0, -delta.y) * panSpeed * Time.deltaTime;

            transform.Translate(move, Space.World);
            lastMousePos = Input.mousePosition;
        }
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
            zoomTargetY = Mathf.Clamp(zoomTargetY - scroll * zoomSpeed, minZoom, maxZoom);

        float smoothY = Mathf.Lerp(transform.position.y, zoomTargetY, Time.deltaTime * 10f);
        transform.position = new Vector3(transform.position.x, smoothY, transform.position.z);
    }
}