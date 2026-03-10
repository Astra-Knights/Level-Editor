using UnityEngine;

public class Utils
{
    public static void DrawLine(Vector3 start, Vector3 end, Transform parent)
    {
        GameObject lineObj = new GameObject("Line");
        lineObj.transform.parent = parent;

        LineRenderer lr = lineObj.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.white;
        lr.endColor = Color.white;
        lr.useWorldSpace = true;
    }
}
