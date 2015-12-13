using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{
    public float health;
    public GameObject deathAnim;
    public void hostileInteraction(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            deathEvent();
        }
    }

    void deathEvent()
    {
		AkSoundEngine.PostEvent ("destroyDrone_explode", gameObject);
        Instantiate(deathAnim, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
