using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
    public float bagStealAmount;
    public float bagStealRate;
    public float leanInfluence;
    private float currentStealRate;

    public GameObject particles;
    void Start()
    {
        particles.SetActive(false);
    }
	void Update ()
    {
	    if(GetComponent<InterceptMotor>().intercepted)
        {
            particles.SetActive(true);
            particles.transform.position = BigDog.instance.transform.position;
            particles.GetComponent<ParticleSystem>().startLifetime = Mathf.Abs(transform.position.x - BigDog.instance.transform.position.x);

            if (currentStealRate < 0)
            {
                Bag.instance.modBagSize(bagStealAmount);
                currentStealRate = bagStealRate;
            }
            else
            {
                currentStealRate -= Time.deltaTime;
            }
            Vector3 dir = transform.position - BigDog.instance.transform.position;
            dir = dir.normalized;
            dir.x = Mathf.Round(dir.x);
            BigDog.instance.GetComponent<Motor>().leanInjection = leanInfluence * -dir.x;
        }
    }
}
