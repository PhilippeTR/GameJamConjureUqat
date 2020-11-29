using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public Rotating underling;
    public int xSpeed;
    public int ySpeed;
    public int zSpeed;
    Vector3 v;
	public int speed;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(xSpeed, ySpeed, zSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
            transform.Rotate(v, speed * Time.deltaTime);
    }
    public void Stop() {
        active = false;
        underling.Stop();
    }
}
