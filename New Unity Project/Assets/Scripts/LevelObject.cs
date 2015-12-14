using UnityEngine;
using System.Collections;

public class LevelObject : MonoBehaviour
{
    public float levelDistance;

    public GameObject[] availableEnemies;
    public float enemySpawnDelayMax;
    public float enemySpawnDelayMin;
    public float enemySpawnZ;

    public GameObject[] availableObstacles;
    public float obstacleSpawnDelayMax;
    public float obstacleSpawnDelayMin;
    public float obstacleSpawnZ;

    public GameObject[] availableSecrets;
    public float secretSpawnDelayMax;
    public float secretSpawnDelayMin;
    public float secretSpawnZ;

    public float returnMin(string type)
    {
        if(type == "enemy")
        {
            return enemySpawnDelayMin;
        }
        else if(type == "obstacle")
        {
            return obstacleSpawnDelayMin;
        }
        else if(type == "secret")
        {
            return secretSpawnDelayMin;
        }
        else
        {
            return 0;
        }
    }
    public float returnMax(string type)
    {
        if (type == "enemy")
        {
            return enemySpawnDelayMax;
        }
        else if (type == "obstacle")
        {
            return obstacleSpawnDelayMax;
        }
        else if (type == "secret")
        {
            return secretSpawnDelayMax;
        }
        else
        {
            return 0;
        }
    }
    public GameObject[] returnObjects(string type)
    {
        if (type == "enemy")
        {
            return availableEnemies;
        }
        else if (type == "obstacle")
        {
            return availableObstacles;
        }
        else if (type == "secret")
        {
            return availableSecrets;
        }
        else
        {
            return null;
        }
    }
    public float returnZ(string type)
    {
        if (type == "enemy")
        {
            return enemySpawnZ;
        }
        else if (type == "obstacle")
        {
            return obstacleSpawnZ;
        }
        else if (type == "secret")
        {
            return secretSpawnZ;
        }
        else
        {
            return 0;
        }
    }
}
