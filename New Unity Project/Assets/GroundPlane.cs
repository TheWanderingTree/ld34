using UnityEngine;
using System.Collections;

public class GroundPlane : MonoBehaviour
{
    public static GroundPlane instance;

    void Awake()
    {
        initInstance();
    }

    void initInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }
}
