using UnityEngine;


public class ToastFly : MonoBehaviour
{


    public float speed;

    private Vector3 _tempTransform;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _tempTransform = Vector3.right;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_tempTransform * (speed * Time.deltaTime));

    }
}
