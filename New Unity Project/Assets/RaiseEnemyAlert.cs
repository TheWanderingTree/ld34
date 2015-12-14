using UnityEngine;
using System.Collections;

public class RaiseEnemyAlert : MonoBehaviour
{
    public float raiseAlertThresh;
    public float screenCenterOffset;
    public float xPosOffset;
    public GameObject alertObj;
    private static GameObject currentAlertObjectL;
    private static GameObject currentAlertObjectR;


    void Update()
    {
        float xPos = (transform.position.x / Mathf.Abs(transform.position.x)) * xPosOffset;
        if(GetComponent<Renderer>().isVisible)
        {
            if (currentAlertObjectR != null)
            {
                Destroy(currentAlertObjectR);
                currentAlertObjectR = null;
            }
            if (currentAlertObjectL != null)
            {
                Destroy(currentAlertObjectL);
                currentAlertObjectL = null;
            }
            enabled = false;
        }
        else
        {
            if (transform.position.z <= raiseAlertThresh)
            {
                if (xPos >= 0 && currentAlertObjectR == null)
                {
                    Vector3 anchor = new Vector3(xPos, screenCenterOffset, 0);
                    currentAlertObjectR = Instantiate(alertObj);
                    currentAlertObjectR.transform.SetParent(UiController.instance.transform);
                    currentAlertObjectR.GetComponent<RectTransform>().anchoredPosition = anchor;
                    AkSoundEngine.PostEvent("UI_obstacleAlert", gameObject);
                }
                if (xPos <= 0 && currentAlertObjectL == null)
                {
                    Vector3 anchor = new Vector3(xPos, screenCenterOffset, 0);
                    currentAlertObjectL = Instantiate(alertObj);
                    currentAlertObjectL.transform.SetParent(UiController.instance.transform);
                    currentAlertObjectL.GetComponent<RectTransform>().anchoredPosition = anchor;
                    AkSoundEngine.PostEvent("UI_obstacleAlert", gameObject);
                }
            }
        }
    }
}
