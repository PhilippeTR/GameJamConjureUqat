using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class FollowingToast : BaseAIController
{

    private Transform watchedTarget;
    public float distanceStartFollow = 5f;
    public GenericAnimationStateMachine animController;
    public string prefix = "";

    protected virtual void Start()
    {
        animController = GetComponentInChildren<GenericAnimationStateMachine>();
        animController.SetLoopedState(ToasterAnim.Idle, prefix, true);
        watchedTarget = GameManager.instance.GetPlayerRef().transform;
    }

    protected override void Update()
    {
        if (target != null)
        {
            float dis = GetDistanceFromTarget();

            agent.SetDestination(target.position);
            animController.SetLoopedState(ToasterAnim.Walking, prefix, true);

            // Stop following player if far enough
            if (dis >= distanceStopFollowing) { target = null; }
        }
        else
        {
            animController.SetLoopedState(ToasterAnim.Idle, prefix, true);
            float dis = Vector3.Distance(this.transform.position, watchedTarget.transform.position);
            // Try Start following
            if (dis <= distanceStartFollow) { SetTarget(watchedTarget); }
        }
    }

    public class ToasterAnim : BaseAnimState
    {
        public static readonly ToasterAnim Walking = new ToasterAnim("ToasterWalkCycle", 1f);
        public static readonly ToasterAnim Idle = new ToasterAnim("Idle", 1f);

        public ToasterAnim(string pClipName, float pSpeed, int pNbVariations = -1) : base(pClipName, pSpeed, pNbVariations)
        { }
    }

}
