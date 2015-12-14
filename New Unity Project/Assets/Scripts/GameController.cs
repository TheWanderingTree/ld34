using UnityEngine;
using UnityEngine.SceneManagement;

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

    public LevelObject[] availableLevels;
    public LevelObject currentLevel
    {
        get;
        private set;
    }
    private int currentLevelIndex = 0;

    public float travelSpeed;
    public float remainingDistance
    {
        get;
        private set;
    }

    private GameObject currentAnimation;

    public GameObject beginAnim;
    public GameObject levelCompleteAnim;
    public GameObject gameOverAnim;

    private float currentTitleLength;

    public float horMoveRange;

    private LevelFactory[] factories;

    void Awake()
    {
        initInstance();
        factories = GetComponents<LevelFactory>();
        currentLevel = availableLevels[currentLevelIndex];


    }
    void Start()
    {
        remainingDistance = currentLevel.levelDistance;
        buildLevel();
        enableFactories(false);
        AkSoundEngine.PostEvent("playTiltAlert", gameObject);

        AkSoundEngine.SetState("Music", "Gameplay");

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
                enableFactories(false);
                BigDog.instance.currentState = BigDog.bigDogStates.immobile;
                if(titleAnimation(beginAnim, 3f))
                {
                    currentState = gameState.inGame;
                }
                break;
            case gameState.idle:
                BigDog.instance.currentState = BigDog.bigDogStates.prefire;
                break;
            case gameState.inGame:
                enableFactories(true);
                BigDog.instance.currentState = BigDog.bigDogStates.mobile;

                if(BigDog.instance.GetComponent<Motor>().hasFallen)
                {

                    BigDog.instance.currentState = BigDog.bigDogStates.fallen;

                    foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                    {
                        if(enemy.GetComponent<Status>())
                        {
                            enemy.GetComponent<Status>().deathEvent();
                        }
                    }
                    currentState = gameState.gameOver;

                }
                else if (traveledDistance())
                {
                    currentState = gameState.levelComplete;
                }
                break;
            case gameState.levelComplete:
                BigDog.instance.currentState = BigDog.bigDogStates.prefire;
                enableFactories(false);
                if (titleAnimation(levelCompleteAnim, 7))
                {
                    if (buildLevel())
                    {
                        currentState = gameState.inGame;
                    }
                }
                break;
            case gameState.gameOver:
                enableFactories(false);
                titleAnimation(gameOverAnim, 5);
                if(Input.anyKey)
                {
                    SceneManager.LoadScene("Main");
                }
                break;
        }
    }

    bool buildLevel()
    {
        if (currentLevelIndex > availableLevels.Length - 1)
        {
            currentLevelIndex = 0;
        }
        currentLevel = availableLevels[currentLevelIndex];
        remainingDistance = currentLevel.levelDistance;

        SkyPlane.instance.GetComponent<Renderer>().material = currentLevel.sky;
        GroundPlane.instance.GetComponent<Renderer>().material = currentLevel.ground;
        currentLevelIndex++;
        return true;
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

    bool titleAnimation(GameObject anim, float length)
    {
        if(currentAnimation == null)
        {
            currentAnimation = Instantiate(anim);
            currentTitleLength = length;
        }

        currentTitleLength -= Time.deltaTime;
        if(currentTitleLength <= 0)
        {
            Destroy(currentAnimation);
            currentAnimation = null;
            return true;
        }
        return false;
    }

    void enableFactories(bool enable)
    {
        foreach(LevelFactory factory in factories)
        {
            factory.enabled = enable;
        }
    }
}
