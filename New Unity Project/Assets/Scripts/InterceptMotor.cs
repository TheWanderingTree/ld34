using UnityEngine;
using System.Collections;

public class InterceptMotor : MonoBehaviour
{
    public float interceptSpeed;
    public float interceptFalloff;

    public GameObject target;

    public bool intercepted = false;
    void Start()
    {
        target = BigDog.instance.gameObject;
    }
    void Update()
    {
        if(transform.position.z < 0)
        {
            moveToIntercept();
        }
        else
        {
            intercepted = true;
        }
    }

    void moveToIntercept()
    {
        Vector3 targetSpeed = Vector3.zero;
        Vector3 speed = transform.forward * interceptSpeed * Time.deltaTime;
        transform.Translate(speed);
    }
    
}
