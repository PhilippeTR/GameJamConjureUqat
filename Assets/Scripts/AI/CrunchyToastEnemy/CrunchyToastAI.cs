using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bytes;

public class CrunchyToastAI : BaseAIController
{

    public string prefix = "CrunchyToastEnemy";
    public int crunchyID;
    public GenericAnimationStateMachine animController;

    protected override void Awake()
    {
        base.Awake();
        animController = GetComponentInChildren<GenericAnimationStateMachine>();
        animController.SetLoopedState(CrunchyToastAnim.Idle, prefix, true);
    }

    protected void Start()
    {
        EventManager.AddEventListener("notifyCrunchyEnemy" + crunchyID, HandleNotified);
    }

    protected override void Update()
    {
        base.Update();
    }

    // This receives a transform (the player transform)
    public void HandleNotified(Bytes.Data data)
    {
        if (target != null) { return; }

        ObjectDataBytes objData = (ObjectDataBytes)data;
        SetTarget((Transform)objData.ObjectValue);
        Animate.Delay(2f, ()=> {
            agent.speed = 3.5f;
            animController.SetLoopedState(CrunchyToastAnim.Walking, prefix, true);
        });
    }


    public class CrunchyToastAnim : BaseAnimState
    {
        public static readonly CrunchyToastAnim Walking = new CrunchyToastAnim("walking", 1f);
        public static readonly CrunchyToastAnim Idle = new CrunchyToastAnim("idle", 1f);

        public CrunchyToastAnim(string pClipName, float pSpeed, int pNbVariations = -1) : base(pClipName, pSpeed, pNbVariations)
        { }
    }

}
