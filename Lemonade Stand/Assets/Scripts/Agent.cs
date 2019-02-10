using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Transform startingPoint;
    public Transform targetPoint;

    public List<Node> pathToTarget = new List<Node>();
    public Path path;

    public bool drawGizmos = true;

    private void OnDrawGizmos()
    {
        if (!drawGizmos)
        {
            return;
        }

        Gizmos.color = Color.green;

        foreach(Node n in pathToTarget)
        {
            Gizmos.DrawSphere(n.position, 0.2f);
        }
    }

    private void Update()
    {
        if (targetPoint == null)
        {
            Debug.LogWarning("target is null");
            return;
        }
        FindPath(startingPoint.position, targetPoint.position);
    }


    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node StartNode = path.GetNodeAtPosition(startPos);
        Node TargetNode = path.GetNodeAtPosition(targetPos);

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
                GetFinalPath(StartNode, TargetNode);
            }

            //Check neighbouring nodes
            foreach (Node NeighborNode in path.GetNeighbours(CurrentNode, path.nodeList))
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

    void GetFinalPath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node CurrentNode = endNode;

        while (CurrentNode != startNode)
        {
            path.Add(CurrentNode);
            CurrentNode = CurrentNode.ParentNode;
        }

        path.Reverse();

        pathToTarget = path;

    }

}