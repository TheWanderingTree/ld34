using UnityEngine;
using System.Collections;

public class RaiseEnemyAlert : MonoBehaviour
{
    public float raiseAlertThresh;
    public float screenCenterOffset;
    public float xPosOffset;
    public GameObject alertObj;
    private GameObject currentAlertObject;

    void Update()
    {
        float xPos = (transform.position.x / transform.position.x) * xPosOffset;
        if(GetComponent<Renderer>().isVisible)
        {
            if (currentAlertObject != null)
            {
                Destroy(currentAlertObject);
                currentAlertObject = null;
            }
        }
        else
        {
            if (transform.position.z <= raiseAlertThresh)
            {
                if (currentAlertObject == null)
                {
                    Vector3 anchor = new Vector3(xPos, screenCenterOffset, 0);
                    currentAlertObject = Instantiate(alertObj);
                    currentAlertObject.transform.SetParent(UiController.instance.transform);
                    currentAlertObject.GetComponent<RectTransform>().anchoredPosition = anchor;
                }
            }
        }
    }
}
