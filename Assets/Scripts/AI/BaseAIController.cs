using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAIController : MonoBehaviour
{
    protected NavMeshAgent agent;

    public Transform target;
    public Vector3 overrideTarget;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

}
