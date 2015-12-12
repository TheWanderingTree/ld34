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

    public enum bigDogStates
    {
        immobile,
        prefire,
        mobile,
        fallen
    }
    public bigDogStates currentState;
    public bool isMobile;
    public bool begin = true;
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
        runStates();
    }

    void runStates()
    {
        switch(currentState)
        {
            case bigDogStates.immobile:
                enableActions(false);
                if(isMobile)
                {
                    currentState = bigDogStates.mobile;
                }
                break;

            case bigDogStates.prefire:
                enableActions(false);
                if(begin)
                {
                    isMobile = true;
                    currentState = bigDogStates.mobile;
                }
                break;
            case bigDogStates.mobile:
                enableActions(true);
                if(GetComponent<Motor>().hasFallen)
                {
                    currentState = bigDogStates.fallen;
                }
                if(!isMobile)
                {
                    currentState = bigDogStates.immobile;
                }
                break;
            case bigDogStates.fallen:
                enableActions(false);
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                break;
        }
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
