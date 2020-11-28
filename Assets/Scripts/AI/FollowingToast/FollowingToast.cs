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
        base.Update();

        if (target != null)
        {
            float dis = GetDistanceFromTarget();
            // Try Start following
            if (dis <= distanceStartFollow) { SetTarget(watchedTarget); }
        }

    }

}
