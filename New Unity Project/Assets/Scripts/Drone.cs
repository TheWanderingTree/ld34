﻿using UnityEngine;
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
        transform.position += new Vector3(0, 0.5f, 0);
    }
	void Update ()
    {
	    if(GetComponent<InterceptMotor>().intercepted)
        {
            particles.SetActive(true);
            particles.transform.position = BigDog.instance.transform.position;
            particles.GetComponent<ParticleSystem>().startLifetime = Mathf.Abs(transform.position.x - BigDog.instance.transform.position.x);

            Vector3 dir = transform.position - BigDog.instance.transform.position;
            dir = dir.normalized;
            dir.x = Mathf.Round(dir.x);

            if (currentStealRate < 0)
            {
                Bag.instance.modBagSize(bagStealAmount);
                currentStealRate = bagStealRate;
                BigDog.instance.GetComponent<Motor>().leanInjection += leanInfluence * -dir.x;
                AkSoundEngine.PostEvent("droneAttack", gameObject);
            }
            else
            {
                currentStealRate -= Time.deltaTime;
            }
        }
    }
}
