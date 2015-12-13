using UnityEngine;
using System.Collections;

public class TimedLife : MonoBehaviour
{
    public float lifeTime;

    public GameObject deathObj;

    void Start()
    {
        transform.SetParent(UiController.instance.transform);
    }
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Instantiate(deathObj, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
