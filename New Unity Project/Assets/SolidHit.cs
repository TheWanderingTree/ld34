using UnityEngine;
using System.Collections;

public class SolidHit : MonoBehaviour
{
    public float hitForce;

    void OnTriggerStay(Collider hit)
    {

        Motor target = hit.GetComponent<Motor>();
        if(target)
        {
            target.leanInjection = 0;
            Vector3 dir = transform.position - BigDog.instance.transform.position;
            dir = dir.normalized;
            dir.x = Mathf.Round(dir.x);
            target.leanInjection = hitForce * dir.x;
            foreach (GameObject cam in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                cam.GetComponent<ScreenShake>().shake();
            }
        }
    }
}
