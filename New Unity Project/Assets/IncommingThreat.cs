using UnityEngine;
using System.Collections;

public class IncommingThreat : MonoBehaviour
{
    public float warnAt = 40f;

    private bool playingSound = false;
	void Update ()
    {
	    if(transform.position.z <= warnAt)
        {
            if(!playingSound)
            {
                AkSoundEngine.PostEvent("UI_obstacleAlert", gameObject);
                playingSound = true;
                UiController.instance.incommingObstacles(true);
            }
            if (transform.position.z <= 0)
            {
                UiController.instance.incommingObstacles(false);
            }
        }
	}
}
