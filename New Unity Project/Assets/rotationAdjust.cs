using UnityEngine;
using System.Collections;

public class rotationAdjust : MonoBehaviour
{
    void Update()
    {
        float target = BigDog.instance.transform.position.x;
        if (transform.position.x > target)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(transform.position.x < target)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }
}
