using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingToast : BaseAIController
{

    private Transform watchedTarget;
    public float distanceStartFollow = 5f;

    protected virtual void Start()
    {
        watchedTarget = GameManager.instance.GetPlayerRef().transform;
    }

    protected override void Update()
    {
        if (target != null)
        {
            float dis = GetDistanceFromTarget();

            agent.SetDestination(target.position);

            // Stop following player if far enough
            if (dis >= distanceStopFollowing) { target = null; }
        }
        else
        {
            float dis = Vector3.Distance(this.transform.position, watchedTarget.transform.position);
            // Try Start following
            if (dis <= distanceStartFollow) { SetTarget(watchedTarget); }
        }
    }

}
