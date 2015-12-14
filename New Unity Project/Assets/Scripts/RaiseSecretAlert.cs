using UnityEngine;
using System.Collections;

public class RaiseSecretAlert : MonoBehaviour
{
    public float raiseAlertThresh;
    public GameObject alertObj;
    public float hoverOffset;

    public GameObject currentAlertObject
    {
        get;
        private set;
    }

    void Update()
    {
        if(transform.position.z <= raiseAlertThresh)
        {
            if(currentAlertObject == null)
            {
                currentAlertObject = Instantiate(alertObj);
                currentAlertObject.transform.SetParent(WorldCanvas.instance.transform);
            }

            Vector3 targetPos = transform.position;
            targetPos.y = targetPos.y + hoverOffset;
            currentAlertObject.transform.position = targetPos;
        }
    }
}
