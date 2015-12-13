using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public enum gameState
    {
        begin,
        idle,
        inGame,
        levelComplete,
        gameOver,

    }
    public gameState currentState;

    public static GameController instance
    {
        get;
        private set;
    }

    public LevelObject currentLevel;

    public float travelSpeed;
    public float remainingDistance
    {
        get;
        private set;
    }

    private GameObject currentAnimation;

    public GameObject beginAnim;
    public float beginAnimLength;
    private float currentBeginLength;
    void Awake()
    {
        initInstance();
    }
    void Start()
    {
        currentBeginLength = beginAnimLength;
        remainingDistance = currentLevel.levelDistance;
    }

    void initInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    void Update()
    {
        runStates();
    }

    void runStates()
    {
        switch(currentState)
        {
            case gameState.begin:
                BigDog.instance.currentState = BigDog.bigDogStates.immobile;
                if(beginningAnimation())
                {
                    currentState = gameState.inGame;
                }
                break;
            case gameState.idle:
                BigDog.instance.currentState = BigDog.bigDogStates.prefire;
                break;
            case gameState.inGame:
                BigDog.instance.currentState = BigDog.bigDogStates.mobile;
                if(traveledDistance())
                {
                    currentState = gameState.levelComplete;
                }
                if(BigDog.instance.GetComponent<Motor>().hasFallen)
                {
                    currentState = gameState.gameOver;
                    BigDog.instance.currentState = BigDog.bigDogStates.fallen;
                }
                break;
            case gameState.levelComplete:
                BigDog.instance.currentState = BigDog.bigDogStates.prefire;
                break;
            case gameState.gameOver:
                break;
        }
    }

    bool traveledDistance()
    {
        remainingDistance -= travelSpeed;
        if(remainingDistance <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool beginningAnimation()
    {
        if(currentAnimation == null)
        {
            currentAnimation = Instantiate(beginAnim);
        }

        currentBeginLength -= Time.deltaTime;
        if(currentBeginLength <= 0)
        {
            Destroy(currentAnimation);
            currentAnimation = null;
            return true;
        }
        return false;
    }
}
