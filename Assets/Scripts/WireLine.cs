using UnityEngine;

public class WireLine : MonoBehaviour
{
    public LineRenderer line;

    public void Draw(Vector3 a, Vector3 b)
    {
        line.positionCount = 2;
        line.SetPosition(0, a);
        line.SetPosition(1, b);
    }
}
