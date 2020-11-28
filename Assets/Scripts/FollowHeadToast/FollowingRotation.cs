using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingRotation : Action
{
    public GameObject followed;
    public Vector3 position;
    public bool active=false;
    public int speedX;
    public int speedY;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            float deltaX = followed.transform.position.x - position.x;
            float deltaY = followed.transform.position.y - position.y;
            float hypo = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);
            speedX = (deltaX/ hypo <= transform.rotation.x)? 1: -1;
            speedY = (deltaY / hypo <= transform.rotation.x) ? 1 : -1;
            Debug.Log("X:"+ speedX + "Y:"+ speedY);
            Vector3 v = new Vector3(speedY, speedX, 0);
            transform.Rotate(v, speed * Time.deltaTime);
        }
    }
    public void executeEnter(GameObject g)
    {
        active = true;
    }
    public void executeStay(GameObject g)
    {

    }
    public void executeLeave(GameObject g)
    {
        active = false;
    }
}
