using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawGizmos : MonoBehaviour
{
    public Path path;
    public float gizmoSize = 0.2f;
    public Color gizmoColor = Color.red;
    public bool drawGizmos = true;
    public List<Node> nodeList = new List<Node>();

    private void OnDrawGizmos()
    {
        if (!drawGizmos)
        {
            return;
        }
        if (nodeList.Capacity < 1)
        {
            Debug.Log("Node list empty");
            nodeList = path.FindNodes();
        }
        
        Gizmos.color = gizmoColor;

        foreach(Node n in nodeList)
        {
            Gizmos.DrawSphere(n.position, gizmoSize);
        }
    }
}
