using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Path : MonoBehaviour
{
    public List<Node> nodeList = new List<Node>();
    public Tilemap tMap;

    private void Awake()
    {
        nodeList = FindNodes();
    }
    public Node GetNodeAtPosition(Vector3 point)
    {
        foreach(var n in nodeList)
        {
            if (Vector3.Distance(n.position, point) <= 2)
            {
                return n;
            }
        }
        return null;
    }

    public List<Node> FindNodes()
    {
        List<Node> nodes = new List<Node>();

        foreach (var pos in tMap.cellBounds.allPositionsWithin)
        {
            Vector3Int posInt = new Vector3Int(pos.x, pos.y, pos.z);
            if (tMap.HasTile(posInt))
            {
                Node n = new Node(tMap.GetCellCenterWorld(posInt));
                nodes.Add(n);               
            }
        }
        return nodes;
    }

    public List<Node> GetNeighbours(Node nodeToCheck, List<Node> nodes)
    {
        List<Node> neighbours = new List<Node>();

        foreach(Node node in nodes)
        {
            if (nodeToCheck == node)
            {
                continue;
            }
            if (Vector3.Distance(nodeToCheck.position, node.position) == tMap.cellSize.x)
            {
                neighbours.Add(node);
            }
        }

        return neighbours;
    }
}
