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
    [HideInInspector] public Vector3 startingPoint;
    [HideInInspector] public Vector3 targetPoint;

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
    [HideInInspector] public bool pathFound = false;
    private Vector3 velocity;
    public float lerpTime = 3.0f;
    public float damping = 1.0f;

    private void OnDrawGizmos()
    {
        if (!drawGizmos)
        {
            return;
        }

        Gizmos.color = Color.green;

        foreach (Node n in waypoints)
        {
            Gizmos.DrawSphere(n.position, 0.2f);
        }
    }

    private void Start()
    {
        path.FindPath(startingPoint, targetPoint, GetComponent<Agent>());
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
            path.FindPath(startingPoint, targetPoint, GetComponent<Agent>());
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
        transform.parent.GetComponent<AgentSpawner>().AgentRemoved();
        Destroy(gameObject);
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
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * lerpTime);
            transform.position += velocity * Time.deltaTime;
            velocity *= (1.0f - Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, waypoints[index].position) < 0.25f)
        {
            index++;
        }
    }
}