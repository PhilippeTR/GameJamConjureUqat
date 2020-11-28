using UnityEngine;
using UnityEngine.AI;

public class ToastFly : MonoBehaviour
{


    public float xSpeed;
    public float ySpeed;
    public float zSpeed;

    public float xAmplitude;
    public float yAmplitude;
    public float zAmplitude;

    private Vector3 _tempTransform;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _tempTransform = transform.parent.localPosition;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _tempTransform.x = Mathf.Sin(Time.realtimeSinceStartup * xSpeed) * xAmplitude;
        _tempTransform.y = Mathf.Sin(Time.realtimeSinceStartup * ySpeed) * yAmplitude;
        _tempTransform.z = Mathf.Sin(Time.realtimeSinceStartup * zSpeed) * zAmplitude;
        transform.position = _tempTransform;

    }
}
