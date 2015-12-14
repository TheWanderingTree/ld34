using UnityEngine;
using System.Collections;

public class SecretPickup : MonoBehaviour
{
    public float sizeIncrease;

    void OnTriggerEnter(Collider hit)
    {
        if(hit.GetComponent<BigDog>())
        {
            AkSoundEngine.PostEvent("UI_confirmMenu", gameObject);
            Bag.instance.modBagSize(sizeIncrease);
            deathEvent();
        }
    }

    void deathEvent()
    {
        Destroy(GetComponent<RaiseSecretAlert>().currentAlertObject);
        Destroy(gameObject);
    }
}
