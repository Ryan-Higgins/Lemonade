using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Increase ai navigation to these areas at these times
 * 1200 
 *      Lunch
 * 1400 
 *      Park
 * 1600
 *      School
 * 1800
 *      Work
 * 
 * Ai starts at 1 of 4 starting points
 * Ai is assigned a target point EG park/bank/school
 * Ai moves to target
 * when ai reaches point ai stops and waits a bit and then disapers and respawns
 * If ai is inrange of the player the ai dosent stop but might slowdown the player clicks on the ai to gain points
 * 
 */


public class Agent : MonoBehaviour
{
    public Transform startingPoint;
    public Transform targetPoint;

    public List<Node> waypoints = new List<Node>();
    private int index = 0;
    
    public Path path;

    public bool drawGizmos = true;

    public float moveSpeed = 1.0f;
    public float banking = 0.1f;
    public float mass = 1.0f;
    public float slowingDist = 0.25f;
    [Tooltip("The minimum distance from the current waypoint to change to the next waypoint")]
    public float nextWaypointDist = 0.125f;

    public bool CanMove = true;
    private bool pathFound = false;
    private Vector3 velocity;
    

    private void OnDrawGizmos()
    {
        if (!drawGizmos)
        {
            return;
        }

        Gizmos.color = Color.green;

        foreach(Node n in waypoints)
        {
            Gizmos.DrawSphere(n.position, 0.2f);
        }
    }

    private void Start()
    {
        FindPath(startingPoint.position, targetPoint.position);
    }

    private void Update()
    {
        if (targetPoint == null)
        {
            Debug.LogWarning("target is null");
            return;
        }
        if (!pathFound)
        {
            FindPath(startingPoint.position, targetPoint.position);
        }

        if (pathFound && CanMove)
        {           

            MoveAgent(waypoints);
        }
        if (!CanMove)
        {
            StopAgent();
        }
        
    }

    public Vector3 Arrive(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        float dist = toTarget.magnitude;

        float ramped = (dist / slowingDist) * moveSpeed;
        float clamped = Mathf.Min(ramped, moveSpeed);
        Vector3 desired = clamped * (toTarget / dist);
        return desired - velocity;
    }

    /// <summary>
    /// Stops the navigation of the agent
    /// </summary>
    private void StopAgent()
    {
        //throw new NotImplementedException();
        Debug.Log("Stop agent");
    }

    /// <summary>
    /// Moves the agent to the waypoints
    /// </summary>
    private void MoveAgent(List<Node> waypoints)
    {

        if (index == waypoints.Count)
        {
            Debug.Log("Destination reached");
            CanMove = false;
            return;
        }

        Vector3 force = Arrive(waypoints[index].position);

        Vector3 acceleration = force / mass;

        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, moveSpeed);


        if (velocity.magnitude > float.Epsilon)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.position += velocity * Time.deltaTime;
            velocity *= (1.0f - Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, waypoints[index].position) < 0.25f)
        {
                index++;
        }
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

        waypoints = path;
        pathFound = true;

    }

}