using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Rotate underling;
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
}
