using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
    public float bagStealAmount;
    public float bagStealRate;
    private float currentStealRate;

	void Update ()
    {
	    if(GetComponent<InterceptMotor>().intercepted)
        {
            if (currentStealRate < 0)
            {
                Bag.instance.modBagSize(bagStealAmount);
                currentStealRate = bagStealRate;
            }
            else
            {
                currentStealRate -= Time.deltaTime;
            }
        }
	}
}
