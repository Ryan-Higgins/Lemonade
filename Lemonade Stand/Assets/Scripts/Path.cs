using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Path : MonoBehaviour
{
    public List<Node> nodeList = new List<Node>();
    private Tilemap tMap;

    private void Awake()
    {
        nodeList = FindNodes();
        ConfigureTilemap();
    }

    private void ConfigureTilemap()
    {
        if (tMap == null)
        {
            if (!GetComponent<Tilemap>())
            {
                Debug.LogError("Tilemap component not found on gameObject");
                return;
            }
            tMap = GetComponent<Tilemap>();
        }
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
        ConfigureTilemap();
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

        if (nodeToCheck == null)
        {
            return neighbours;
        }

        foreach (Node node in nodes)
        {
            if (nodeToCheck == node)
            {
                continue;
            }
            if (node == null)
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

    public void FindPath(Vector3 startPos, Vector3 targetPos, Agent agent)
    {
        Node StartNode = GetNodeAtPosition(startPos);
        Node TargetNode = GetNodeAtPosition(targetPos);

        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();

        OpenList.Add(StartNode);

        while (OpenList.Count > 0)
        {
            Node CurrentNode = OpenList[0];
            for (int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].totalCost < CurrentNode.totalCost || OpenList[i].totalCost == CurrentNode.totalCost
                    && OpenList[i].costFromTarget < CurrentNode.costFromTarget)
                {
                    CurrentNode = OpenList[i];
                }
            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode, agent);
            }

            //Check neighbouring nodes
            foreach (Node NeighborNode in GetNeighbours(CurrentNode, nodeList))
            {
                if (ClosedList.Contains(NeighborNode))
                {
                    continue;
                }
                int MoveCost = CurrentNode.costFromStart + (int)Vector3.Distance(CurrentNode.position, NeighborNode.position);

                if (MoveCost < NeighborNode.costFromStart || !OpenList.Contains(NeighborNode))
                {
                    NeighborNode.costFromStart = MoveCost;
                    NeighborNode.costFromTarget = (int)Vector3.Distance(CurrentNode.position, NeighborNode.position);
                    NeighborNode.ParentNode = CurrentNode;

                    if (!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }

        }
    }

    void GetFinalPath(Node startNode, Node endNode, Agent agent)
    {
        List<Node> path = new List<Node>();
        Node CurrentNode = endNode;

        while (CurrentNode != startNode)
        {
            path.Add(CurrentNode);
            CurrentNode = CurrentNode.ParentNode;
        }

        path.Reverse();

        agent.waypoints = path;
        agent.pathFound = true;

    }
}
