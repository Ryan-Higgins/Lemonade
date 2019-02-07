using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Path : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public Tilemap tMap;

    private void Awake()
    {
        waypoints = FindWaypoints(tMap);
    }

    public static List<Vector3> FindWaypoints(Tilemap tMap)
    {
        List<Vector3> points = new List<Vector3>();
        foreach (var pos in tMap.cellBounds.allPositionsWithin)
        {
            if (tMap.HasTile(new Vector3Int(pos.x, pos.y, pos.z)))
            {
                Vector3 p = tMap.CellToWorld(new Vector3Int(pos.x, pos.y, pos.z));

                points.Add(p + new Vector3(1, 1, 0));
            }
        }
        return points;
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void GeneratePathTo(int x, int y)
    //{
    //    Dictionary<Node, float> dist = new Dictionary<Node, float>();
    //    Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

    //    // Setup the "Q" -- the list of nodes we haven't checked yet.
    //    List<Node> unvisited = new List<Node>();

    //    Node source = graph[
    //                        selectedUnit.GetComponent<Unit>().tileX,
    //                        selectedUnit.GetComponent<Unit>().tileY
    //                        ];

    //    Node target = graph[
    //                        x,
    //                        y
    //                        ];

    //    dist[source] = 0;
    //    prev[source] = null;

    //    // Initialize everything to have INFINITY distance, since
    //    // we don't know any better right now. Also, it's possible
    //    // that some nodes CAN'T be reached from the source,
    //    // which would make INFINITY a reasonable value
    //    foreach (Node v in graph)
    //    {
    //        if (v != source)
    //        {
    //            dist[v] = Mathf.Infinity;
    //            prev[v] = null;
    //        }

    //        unvisited.Add(v);
    //    }

    //    while (unvisited.Count > 0)
    //    {
    //        // "u" is going to be the unvisited node with the smallest distance.
    //        Node u = null;

    //        foreach (Node possibleU in unvisited)
    //        {
    //            if (u == null || dist[possibleU] < dist[u])
    //            {
    //                u = possibleU;
    //            }
    //        }

    //        if (u == target)
    //        {
    //            break;  // Exit the while loop!
    //        }

    //        unvisited.Remove(u);

    //        foreach (Node v in u.neighbours)
    //        {
    //            //float alt = dist[u] + u.DistanceTo(v);
    //            float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
    //            if (alt < dist[v])
    //            {
    //                dist[v] = alt;
    //                prev[v] = u;
    //            }
    //        }
    //    }

    //    // If we get there, the either we found the shortest route
    //    // to our target, or there is no route at ALL to our target.

    //    if (prev[target] == null)
    //    {
    //        // No route between our target and the source
    //        return;
    //    }

    //    List<Node> currentPath = new List<Node>();

    //    Node curr = target;

    //    // Step through the "prev" chain and add it to our path
    //    while (curr != null)
    //    {
    //        currentPath.Add(curr);
    //        curr = prev[curr];
    //    }

    //    // Right now, currentPath describes a route from out target to our source
    //    // So we need to invert it!

    //    currentPath.Reverse();

    //}
}
