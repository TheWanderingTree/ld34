using UnityEngine;
using System.Collections;

public class SolidHit : MonoBehaviour
{
    public float hitForce;

    void OnTriggerEnter(Collider hit)
    {
        Motor target = hit.GetComponent<Motor>();
        if(target)
        {
            target.leanInjection = hitForce;
            foreach (GameObject cam in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                cam.GetComponent<ScreenShake>().shake();
            }
        }
    }
}
