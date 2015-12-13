using UnityEngine;
using System.Collections;

public class WwiseGlobal : MonoBehaviour
{
    public static WwiseGlobal instance;

    void Awake()
    {
        initInstance();
    }

    void initInstance()
    {
        instance = this;
    }
}
