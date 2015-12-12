using UnityEngine;
using System.Collections;

public class BigDog : MonoBehaviour
{
    public float hostileInteractionDelay;

    public string[] hostileTags;

    public static BigDog instance
    {
        get;
        private set;
    }
    public IActionController[] actions
    {
        get;
        private set;
    }

    void Awake()
    {
        initInstance();
        initActions();
    }

    void initInstance()
    {
        if(instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    void initActions()
    {
        actions = GetComponents<IActionController>();
    }

    void Update()
    {

    }

    void enableActions(bool enable)
    {
        foreach (IActionController action in actions)
        {
            action.enableActions = enable;
        }
    }

    bool checkIfHostile(string hostile)
    {
        foreach(string tag in hostileTags)
        {
            if(tag == hostile)
            {
                return true;
            }
        }
        return false;
    }
}
