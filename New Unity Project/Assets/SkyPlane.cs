using UnityEngine;
using System.Collections;

public class SkyPlane : MonoBehaviour
{
    public static SkyPlane instance;

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
