using UnityEngine;

public class Node
{
    public Vector3 position;

    public Node ParentNode;

    public int costFromStart;
    public int costFromTarget;
    public int totalCost { get { return costFromStart + costFromTarget; } }

    public Node(Vector3 pos)
    {
        this.position = pos;
    }

}
