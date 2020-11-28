using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAIController : MonoBehaviour
{
    protected NavMeshAgent agent;

    public Transform target;
    public Vector3 overrideTarget;

    public float distanceStopFollowing = 8f;

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
            float dis = GetDistanceFromTarget();

            agent.SetDestination(target.position);

            // Stop following player if far enough
            if (dis >= distanceStopFollowing) { target = null; }
        }
    }

    protected virtual float GetDistanceFromTarget()
    {
        return Vector3.Distance(this.transform.position, target.position);
    }

}
