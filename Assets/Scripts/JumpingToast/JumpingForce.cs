using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingForce : MonoBehaviour
{
    public GameObject trigger;
    public GameObject toastJ;
    public GameObject reset;
    public int velocityX;
    public int velocityY;
    public int velocityZ;
    public bool inMove = true; 
    private Rigidbody rbToast;

    // Start is called before the first frame update
    void Start()
    {
        rbToast = toastJ.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inMove) {
            rbToast.velocity = new Vector3(velocityX, velocityY, velocityZ);
            inMove = true;
        }
            
    }
    public void ResetTrigger(bool val) {
        inMove = val;
        rbToast.velocity = new Vector3(0, 0, 0);
    }

    public void StartGravity()
    {
        rbToast.useGravity = true;
    }

}
