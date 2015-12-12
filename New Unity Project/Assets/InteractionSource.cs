using UnityEngine;
using System.Collections;

public class InteractionSource : MonoBehaviour
{
    public float hitForce;

    void OnCollisionEnter(Collision hit)
    {
        Motor target = hit.collider.GetComponent<Motor>();
        if(target)
        {
            target.leanInjection = hitForce;
        }
    }
}
