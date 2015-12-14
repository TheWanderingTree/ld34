using UnityEngine;
using System.Collections;

public class LevelFactory : MonoBehaviour
{
    public float horSpawnBuffer = 1;
    public enum factoryType
    {
        Enemy,
        Obstacle,
        Secret
    }
    public factoryType levelFactoryType;

    private float horSpawnRange;
    private LevelObject useLevel;

    private float minDelay;
    private float maxDelay;
    private GameObject[] objects;
    private float spawnZ;
    private int count;

    private GameController control;

    private float currentTimer;

    void Start()
    {
        control = GameController.instance;
        useLevel = control.currentLevel;
        string type = getFactoryType(levelFactoryType);
        minDelay = useLevel.returnMin(type);
        maxDelay = useLevel.returnMax(type);
        objects = useLevel.returnObjects(type);
        count = objects.Length;
        spawnZ = useLevel.returnZ(type);
    }

    string getFactoryType(factoryType type)
    {
        switch(type)
        {
            case factoryType.Enemy:
                return "enemy";
            case factoryType.Obstacle:
                return "obstacle";
            case factoryType.Secret:
                return "secret";
        }
        return "";
    }
    void Update()
    {
        if(control.remainingDistance > 0 && count > 0)
        {
            controlSpawn();
        }
    }

    void controlSpawn()
    {
        if(currentTimer <= 0)
        {
            spawnObject(objects);
            currentTimer = Random.Range(minDelay, maxDelay);
        }
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
    }

    void spawnObject(GameObject[] objSet)
    {
        int index = Random.Range(0, count);
        float horPosMax = Random.Range(horSpawnBuffer, control.horMoveRange);
        float horPosMin = -Random.Range(horSpawnBuffer, control.horMoveRange);
        float horPos = Random.Range(horPosMin, horPosMax);
        Vector3 spawn = new Vector3(horPos, 0, spawnZ);
        Instantiate(objSet[index], spawn, Quaternion.identity);
    }
}
