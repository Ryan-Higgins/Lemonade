using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Transform startPos;
    public Transform targetPos;
    public Transform nextWaypoint;

    public Queue<Transform> waypoints = new Queue<Transform>();

    public List<Transform> visited = new List<Transform>();

    private void Awake()
    {
        waypoints.Enqueue(startPos);
        visited.Add(startPos);

        while(waypoints.Count > 1)
        {
            var current = waypoints.Peek();

            //foreach (var next in )
        }
    }

}

public struct Node
{
    public List<Node> neighbours;
    public Vector3 pos;
}

/*
 * public class ForForum : MonoBehaviour
{
    // IntVector2 - custom struct (basically a copy of Vector2 with int's)
    // GetNeighbors - function to get the neighbors of the current cell
   
   
    Dictionary<IntVector2, int> distanceChart = new Dictionary<IntVector2, int>();                        // this will record the distances from start to all positions on map
    Dictionary<IntVector2, IntVector2> pathChart = new Dictionary<IntVector2, IntVector2>();            // this will record the / a shortest path from start to all positions on map
   
    public void BFS(IntVector2 startPos)
    {
        IntVector2 currentPos = startPos;
        Queue<IntVector2> frontier = new Queue<IntVector2>();
       
        distanceChart.Clear();
        pathChart.Clear();
       
        frontier.Enqueue(currentPos);
        distanceChart.Add(currentPos, 0);
        pathChart.Add(currentPos, IntVector2.downLeft);                                            // IntVector2.downLeft = marker for start position
       
        while (frontier.Count > 0)                                                                // have I not been everywhere
        {
            currentPos = frontier.Dequeue();                                                    // get position I am currently at
            foreach (IntVector2 nextPos in GetNeighbors (currentPos))                            // get a list of all my neighbors
            {
                if (distanceChart.ContainsKey(nextPos) == false)                                // if I have not been on the neighbor cell, process
                {
                    frontier.Enqueue(nextPos);                                              
                    distanceChart.Add(nextPos, 1 + distanceChart[currentPos]);
                    pathChart.Add(nextPos, currentPos);
                   
                    // here can go further logic
                    // i.e. stop once next enemy found
                    // or create a distance list to all enemy positions
                }
            }
        }
    }
}
 
 * 
 * 
 */
