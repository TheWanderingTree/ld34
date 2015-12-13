using UnityEngine;
using System.Collections;

public class UiController : MonoBehaviour
{
    public static UiController instance
    {
        get;
        private set;
    }

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
}
