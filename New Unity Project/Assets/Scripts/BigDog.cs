using UnityEngine;
using DG.Tweening;

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
        fallen,
        dead
    }
    public bigDogStates currentState;
    public bool isMobile;
    public bool begin = true;

    [Header("Skid Control")]
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;

    private Tween currentTween;

    uint currentSound;
    void Awake()
    {
        initInstance();
        initActions();
    }

    void initInstance()
    {
        if (instance != null)
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
        switch (currentState)
        {
            case bigDogStates.immobile:
                enableActions(false);
                break;

            case bigDogStates.prefire:
                enableActions(false);
                break;
            case bigDogStates.mobile:
                enableActions(true);
                break;
            case bigDogStates.fallen:
                if (currentTween == null)
                {
                    currentTween = transform.DOShakePosition(duration, strength, vibrato, randomness);
                    AkSoundEngine.PostEvent("stopBigDog", gameObject);
                }
                enableActions(false);
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.rotation = Quaternion.identity;
                if (Bag.instance.GetComponent<HingeJoint>())
                {
                    Bag.instance.GetComponent<HingeJoint>().breakForce = 0;
                }
                GetComponent<Animator>().SetBool("Fallen", true);
                currentState = bigDogStates.dead;
                break;
            case bigDogStates.dead:
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
        foreach (string tag in hostileTags)
        {
            if (tag == hostile)
            {
                return true;
            }
        }
        return false;
    }
}
