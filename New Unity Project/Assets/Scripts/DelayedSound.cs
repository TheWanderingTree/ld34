using UnityEngine;
using System.Collections;

public class DelayedSound : MonoBehaviour
{
    public float delayTime;

    private bool sound;
    void Update()
    {
        delayTime -= Time.deltaTime;
        if(delayTime <= 0 && !sound)
        {
            AkSoundEngine.PostEvent("VO_gametitle", gameObject);
            sound = true;
        }
    }
}
