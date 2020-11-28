using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int xSpeed;
    public int ySpeed;
    public int zSpeed;
    Vector3 v;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(xSpeed, ySpeed, zSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(v, speed * Time.deltaTime);
    }
}
