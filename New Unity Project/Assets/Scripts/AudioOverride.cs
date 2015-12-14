using UnityEngine;
using System.Collections;

public class AudioOverride : MonoBehaviour
{
    public string masterClip;
    void Start()
    {
        AkSoundEngine.StopAll();
        AkSoundEngine.PostEvent(masterClip, gameObject);
    }
}
