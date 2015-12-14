using UnityEngine;
using System.Collections;

public class WorldCanvas : MonoBehaviour
{
    public static WorldCanvas instance
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
