using UnityEngine;
using System.Collections;

public class InterceptMotor : MonoBehaviour
{
    public float interceptSpeed;
    public float interceptFalloff;

    public GameObject target;
    void Start()
    {
        target = BigDog.instance.gameObject;
    }
    void Update()
    {
        if(transform.position.y < 0)
        {
            moveToIntercept();
        }
        else
        {
        }
    }

    void moveToIntercept()
    {
        Vector3 targetSpeed = Vector3.zero;
        Vector3 speed = Vector3.up * interceptSpeed * Time.deltaTime;
        transform.Translate(speed);
    }
    
}
