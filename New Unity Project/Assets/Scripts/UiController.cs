using UnityEngine;
using System.Collections;

public class UiController : MonoBehaviour
{
    public static UiController instance
    {
        get;
        private set;
    }

    public GameObject obstaclesAlert;

    void Awake()
    {
        initInstance();
    }

    void initInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public void incommingObstacles(bool incomming)
    {
        if (incomming && !obstaclesAlert.activeSelf)
        {
            obstaclesAlert.SetActive(true);
        }
        else if (!incomming && obstaclesAlert.activeSelf)
        {
            obstaclesAlert.SetActive(false);
        }
    }
}
