using UnityEngine;
using System.Collections;

public class ObjectMotor : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = direction * speed;
    }
}
