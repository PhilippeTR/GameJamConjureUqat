using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

public class PlayerController : Bytes.Controllers.FPSController
{

    public float gluten = 100f;
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
    }

    protected override void Update()
    {
        if (!canBeControlled) { return; }
        _Movement_Update();
        _Camera_Update();
        _Controls_Update();
        _PickItem_Update();
    }
    
    public void AddGluten(float amount)
    {
        gluten = Mathf.Clamp(gluten + amount, 0, 100);
        glutenBar.SetHealth(gluten);
        if (gluten >= 100) { Die(); }
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

}