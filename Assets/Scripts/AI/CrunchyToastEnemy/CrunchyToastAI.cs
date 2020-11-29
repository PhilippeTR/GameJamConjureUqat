using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bytes;

public class CrunchyToastAI : BaseAIController
{

    private Vector3 initialPos;

    public string prefix = "CrunchyToastEnemy";
    public int crunchyID;
    public GenericAnimationStateMachine animController;
    public float inactiveSpeed = 0.25f;

    private bool moving = false;
    private bool canReturnToInitialPos = false;

    private Animate delayChasePlayer;
    private Animate delayCanReturnToInitPos;

    protected override void Awake()
    {
        base.Awake();
        animController = GetComponentInChildren<GenericAnimationStateMachine>();
        animController.SetLoopedState(CrunchyToastAnim.Idle, prefix, true);

        initialPos = this.transform.position;
        agent.speed = inactiveSpeed;
    }

    protected void Start()
    {
        EventManager.AddEventListener("notifyCrunchyEnemy" + crunchyID, HandleNotified);
    }

    protected override void Update()
    {
        if (target != null)
        {
            float dis = GetDistanceFromTarget();

            agent.SetDestination(target.position);
            

            // Stop following player if far enough
            if (dis >= distanceStopFollowing && moving && canReturnToInitialPos) { ReturnToInitialPos(); }
        }
        else
        {
            // Return to initial pos
            float dis = Vector3.Distance(this.transform.position, initialPos);
            if (dis <= 0.3f)
            {
                animController.SetLoopedState(CrunchyToastAnim.Idle, prefix, true);
                agent.speed = inactiveSpeed;
            }
            agent.SetDestination(initialPos);
        }
    }

    // This receives a transform (the player transform)
    public void HandleNotified(Bytes.Data data)
    {
        if (target != null) { return; }

        ObjectDataBytes objData = (ObjectDataBytes)data;
        SetTarget((Transform)objData.ObjectValue);
        canReturnToInitialPos = false;

        delayChasePlayer = Animate.Delay(2f, ()=>
        {
            moving = true;
            agent.speed = 4f;
            EventManager.Dispatch("playSound", new PlaySoundData("HORROR_HelpMe002"));
            animController.SetLoopedState(CrunchyToastAnim.Walking, prefix, true);

            // Set atk collider on
            GetComponentInChildren<Damage>().GetComponent<Collider>().gameObject.SetActive(true);

            // Has 3 seconds to close gap between him and player before having to return to inital pos if hes too far from player
            delayCanReturnToInitPos = Animate.Delay(3f, ()=> {
                canReturnToInitialPos = true;
            });
        });
    }

    protected void ReturnToInitialPos()
    {
        target = null;
        moving = false;
        canReturnToInitialPos = false;

        GetComponentInChildren<Damage>().GetComponent<Collider>().gameObject.SetActive(false);

        delayChasePlayer?.Stop(false);
        delayCanReturnToInitPos?.Stop(false);
    }

    public class CrunchyToastAnim : BaseAnimState
    {
        public static readonly CrunchyToastAnim Walking = new CrunchyToastAnim("walking", 1f);
        public static readonly CrunchyToastAnim Idle = new CrunchyToastAnim("idle", 1f);

        public CrunchyToastAnim(string pClipName, float pSpeed, int pNbVariations = -1) : base(pClipName, pSpeed, pNbVariations)
        { }
    }

}
