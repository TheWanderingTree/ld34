using UnityEngine;
using System.Collections;

public class Segway : MonoBehaviour
{
    public float attackSpeed;

    [Range(0f,1f)]
    public float acceleration;

    public float recoilLength;
    private float currentRecoilLength;

    private bool isRecoil;
    private InterceptMotor motor;
    private Rigidbody rigid;
    void Awake()
    {
        motor = GetComponent<InterceptMotor>();
        rigid = GetComponent<Rigidbody>();
        currentRecoilLength = recoilLength;
    }

    void FixedUpdate()
    {
        if(motor)
        {
            if(motor.intercepted)
            {
                attack();
                if (!GetComponent<Animator>().GetBool("Attacking"))
                {
                    GetComponent<Animator>().SetBool("Attacking", true);
                }
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "Player")
        {
            if (!isRecoil)
            {
                isRecoil = true;
            }
        }
    }
    
    void attack()
    {
        float reverse = 1;
        if(isRecoil)
        {
            reverse = -1;
            currentRecoilLength -= Time.deltaTime;
            if(currentRecoilLength <= 0)
            {
                isRecoil = false;
            }
        }
        else
        {
            reverse = 1;
            currentRecoilLength = recoilLength;
        }
        Vector3 targetSpeed = -transform.right * reverse * attackSpeed;
        Vector3 newSpeed = Vector3.Lerp(rigid.velocity, targetSpeed, acceleration);
        rigid.velocity = newSpeed;
    }
}
