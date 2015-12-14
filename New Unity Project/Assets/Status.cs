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

    public void deathEvent()
    {
		AkSoundEngine.PostEvent ("explosion", gameObject);
        Instantiate(deathAnim, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
