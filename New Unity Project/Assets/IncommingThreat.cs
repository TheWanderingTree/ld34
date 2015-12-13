using UnityEngine;
using System.Collections;

public class IncommingThreat : MonoBehaviour
{
    public float warnAt = 40f;

	void Update ()
    {
	    if(transform.position.z <= warnAt)
        {
            UiController.instance.incommingObstacles(true);
            if (transform.position.z <= 0)
            {
                UiController.instance.incommingObstacles(false);
            }
        }
	}
}
