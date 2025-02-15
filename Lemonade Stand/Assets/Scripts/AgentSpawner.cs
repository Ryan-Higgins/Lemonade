﻿using System;
using System.Collections;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPoints;
    [SerializeField] private Destination[] destinations;
    public bool drawGizmos = false;
    public float numToSpawn = 5;
    private float agentCount = 0;
    [SerializeField] private MoveSpeed moveSpeed;
    public float spawnInterval = 0.5f;

    private Path path;
    [Serializable]
    private struct Destination
    {
        public Transform trans;
        public int weight;
        public WeatherType weatherType;
        public EventTypes eventType;
    }
    [Serializable]
    private struct MoveSpeed
    {
        public float minSpeed;
        public float maxSpeed;
    }
    private void Start()
    {
        path = GameObject.FindObjectOfType<Path>();
        //for(int i = 0; i < numToSpawn; i++)
        //{
        //    SpawnAgent();
        //}
        StartCoroutine(SpawnAgentRoutine());
    }
    private void Update()
    {
        StartCoroutine(SpawnAgentRoutine());

        for (int i = 0; i < destinations.Length; i++)
        {
            if (destinations[i].weatherType == Weather.weatherType || destinations[i].eventType == Events.type)
            {
                destinations[i].weight = 10;
            }
            else
            {
                destinations[i].weight = 5;
            }
        }
    }

    private IEnumerator SpawnAgentRoutine()
    {
        if (agentCount < (numToSpawn + 1))
        {
            SpawnAgent();
            agentCount++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void AgentRemoved()
    {
        agentCount--;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (drawGizmos)
        {
            foreach (Destination p in destinations)
            {
                Gizmos.DrawSphere(p.trans.position, 0.3f);
            }
        }
    }


    public void SpawnAgent()
    {
        Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        GameObject agent = Instantiate(prefab, spawnPoint);
        agent.transform.parent = transform;
        agent.transform.localScale = Vector3.one;
        Agent a = agent.GetComponent<Agent>();
        a.startingPoint = path.GetNodeAtPosition(spawnPoint.position).position;
        a.targetPoint = destinations[GetRandomWeightedIndex()].trans.position;
        a.path = path;
        a.CanMove = true;
        a.moveSpeed = UnityEngine.Random.Range(moveSpeed.minSpeed, moveSpeed.maxSpeed);
        agent.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y, -3);

    }
    public int GetRandomWeightedIndex()
    {
        int weightSum = 0;
        foreach (Destination d in destinations)
        {
            weightSum += d.weight;
        }

        int index = 0;
        int lastIndex = destinations.Length - 1;
        while (index < lastIndex)
        {
            if (UnityEngine.Random.Range(0, weightSum) < destinations[index].weight)
            {
                return index;
            }
            weightSum -= destinations[index++].weight;
        }
        return index;
    }
}

