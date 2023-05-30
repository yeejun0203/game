using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacle;
    public List<Transform> spawnPoints;

    private GameObject obstacleA;
    private GameObject obstacleB;
    private GameObject obstacleC;

    private void Start()
    {
        int random = Random.Range(0, 6);
        GenerateObstacle(0);
    }

    void GenerateObstacle(int randomNum)
    {
        switch (randomNum)
        {
            case 0:
                obstacleA = Instantiate(obstacle[2], spawnPoints[Random.Range(0, 3)].position, transform.rotation);
                obstacleB = Instantiate(obstacle[1], spawnPoints[Random.Range(3, 6)].position, transform.rotation);
                obstacleC = Instantiate(obstacle[2], spawnPoints[Random.Range(6, 9)].position, transform.rotation);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    private void OnDisable()
    {
        Destroy(obstacleA);
        Destroy(obstacleB);
        Destroy(obstacleC);
    }
}
