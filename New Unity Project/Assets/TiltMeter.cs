using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TiltMeter : MonoBehaviour
{
    public bool left;
    private Motor target;

    private float currentValue;
    private float maxValue;
    private float fill;
	void Start ()
    {
        target = BigDog.instance.GetComponent<Motor>();
	}
	
	void Update ()
    {
        if (left)
        {
            if (target.currentDirection == 1)
            {
                currentValue = 1 - (target.currentTimeToFall / target.timeToFall);
                GetComponent<Image>().fillAmount = currentValue;
            }
        }
        else if (!left)
        {
            if (target.currentDirection == -1)
            {
                currentValue = 1 - (target.currentTimeToFall / target.timeToFall);
                GetComponent<Image>().fillAmount = currentValue;
            }
        }

    }
}
