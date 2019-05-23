using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monster : MonoBehaviour
{
    public Transform victim;
    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = victim.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (victim)
        {
            agent.SetDestination(victim.position);
        }
    }
}
