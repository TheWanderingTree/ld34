using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{
    public float health;

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
        Destroy(gameObject);
    }
}
