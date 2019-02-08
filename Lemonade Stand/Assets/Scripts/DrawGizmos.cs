using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawGizmos : MonoBehaviour
{
    public Tilemap tMap;
    List<Vector3> points = new List<Vector3>();
    public Vector3 gizmoOffset = new Vector3(1, 1, 0);
    public float gizmoSize = 0.2f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (points.Count < 1)
        {
            points = Path.FindWaypoints(tMap);
        }

        foreach (var pos in tMap.cellBounds.allPositionsWithin)
        {
            if (tMap.HasTile(new Vector3Int(pos.x, pos.y, pos.z))){
                Vector3 p = tMap.CellToWorld(new Vector3Int(pos.x, pos.y, pos.z));
                
                Gizmos.DrawSphere(p + gizmoOffset, gizmoSize);
            }
        }
    }
}
