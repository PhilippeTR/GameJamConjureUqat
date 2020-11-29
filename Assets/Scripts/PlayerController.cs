using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class PlayerController : Bytes.Controllers.FPSController
{

    private GenericAnimationStateMachine animController;

    public float gluten = 0f;
    public bool alive = true;

    public Rigidbody pickedItem;
    public Transform pickedItemTarget;

    public float forceTowardPickedObj = 12f;

    public GlutenBar glutenBar;

    public void Start()
    {
        pickedItem = null;
        EventManager.AddEventListener(EventNames.playerGlutenUpdate, HandleGlutenUpdate);
        glutenBar.SetMinHealth(0f);
        animController = GetComponentInChildren<GenericAnimationStateMachine>();
    }

    protected override void Update()
    {
        if (!canBeControlled) { return; }
        float vitesse = _Movement_Update();
        _Camera_Update();
        _Controls_Update();
        _PickItem_Update();

        if (vitesse > 0)
        {
            PlayerAnim used = PlayerAnim.Walking;
            if (vitesse > walkingSpeed) { used = PlayerAnim.Running; print("Running"); }
            animController.SetLoopedState(used, "", true);
        }
        else
        {
            animController.SetLoopedState(PlayerAnim.Idle, "", true);
        }
    }
    
    public void AddGluten(float amount)
    {
        gluten = Mathf.Clamp(gluten + amount, 0, 100);
        if (gluten >= 100) { Die(); }

        glutenBar.SetHealth(gluten);
    }

    protected void Die()
    {
        if (!alive) { return; }


        alive = false;
    }

    private void HandleGlutenUpdate(Data data)
    {
        IntDataBytes casted = (IntDataBytes) data;
        AddGluten((float)casted.IntValue);
        
    }

    protected virtual void _PickItem_Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pickedItem != null)
            {
                pickedItem.freezeRotation = false;
                pickedItem = null;
            }
            else if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Pickable")
                {
                    pickedItem = hit.transform.GetComponent<Rigidbody>();
                    pickedItem.freezeRotation = true;
                }
            }
        }

        if (pickedItem != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                YeetusTheFeetus();
                return;
            }
            // Picked item update
            Vector3 dir = pickedItemTarget.position - pickedItem.transform.position;
            dir.Normalize();
            float dis = Vector3.Distance(pickedItemTarget.position, pickedItem.position);
            pickedItem.velocity = dir * (forceTowardPickedObj * dis);
       }

    }

    protected void YeetusTheFeetus()
    {
        Vector3 dir = pickedItemTarget.position - Camera.main.transform.position;
        pickedItem.velocity = dir * 15f / (pickedItem.mass / 2f);
        pickedItem.freezeRotation = false;
        pickedItem = null;
    }



    public class PlayerAnim : BaseAnimState
    {
        public static PlayerAnim Walking = new PlayerAnim("Swagger Walk", 1f);
        public static PlayerAnim Running = new PlayerAnim("Swagger Walk", 1.5f);
        public static PlayerAnim Idle = new PlayerAnim("Idle", 1f);
        public static PlayerAnim Die = new PlayerAnim("Idle", 1f);

        public PlayerAnim(string pClipName, float pSpeed, int pNbVariations = -1) : base(pClipName, pSpeed, pNbVariations)
        { }
    }

}