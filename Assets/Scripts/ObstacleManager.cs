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
        int random = Random.Range(0, 3);
        GenerateObstacle(random);
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
                obstacleA = Instantiate(obstacle[2], spawnPoints[Random.Range(0, 3)].position, transform.rotation);
                obstacleB = Instantiate(obstacle[2], spawnPoints[Random.Range(3, 6)].position, transform.rotation);
                obstacleC = Instantiate(obstacle[2], spawnPoints[Random.Range(6, 9)].position, transform.rotation);
                break;
            case 2:
                obstacleA = Instantiate(obstacle[0], spawnPoints[FrontNum(0)].position, transform.rotation);
                obstacleB = Instantiate(obstacle[1], spawnPoints[FrontNum(1)].position, transform.rotation);
                obstacleC = Instantiate(obstacle[0], spawnPoints[FrontNum(2)].position, transform.rotation);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }
    int FrontNum(int i)
    {
        int num = 0;
        if (i == 0)
        {
            int[] a = { 0, 3, 6 };
            num = a[Random.Range(0, 3)];
        }
        else if (i == 1)
        {
            int[] a = { 1, 4, 7 };
            num = a[Random.Range(0, 3)];
        }
        else if (i == 2)
        {
            int[] a = { 2, 5, 8 };
            num = a[Random.Range(0, 3)];
        }
        return num;
    }

    private void OnDisable()
    {
        Destroy(obstacleA);
        Destroy(obstacleB);
        Destroy(obstacleC);
    }
}
