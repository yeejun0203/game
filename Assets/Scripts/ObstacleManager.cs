using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacle; // 0번 길쭉한거 1번 작은거 2번 키 큰거
    public List<Transform> spawnPoints; // 왼쪽 위부터 0 1 2 ...
    public bool isStart;

    private GameObject obstacleA;
    private GameObject obstacleB;
    private GameObject obstacleC;
    private GameObject obstacleD;
    private GameObject obstacleE;
    private GameObject obstacleF;
    int random;

    private void Start()
    {
        if (isStart)
        {
            random = 7;
        } else
        {
            random = Random.Range(0, 8);
        }
        GenerateObstacle(random);
    }

    void GenerateObstacle(int randomNum)
    {
        switch (randomNum)
        {
            case 0: // 키 큰거 2개 랜덤 생성 작은거 한 개 랜덤 생성
                obstacleA = Instantiate(obstacle[2], spawnPoints[Random.Range(0, 3)].position, transform.rotation);
                obstacleB = Instantiate(obstacle[1], spawnPoints[Random.Range(3, 6)].position, transform.rotation);
                obstacleC = Instantiate(obstacle[2], spawnPoints[Random.Range(6, 9)].position, transform.rotation);
                break;
            case 1: // 키 큰거 3개 랜덤 생성
                obstacleA = Instantiate(obstacle[2], spawnPoints[Random.Range(0, 3)].position, transform.rotation);
                obstacleB = Instantiate(obstacle[2], spawnPoints[Random.Range(3, 6)].position, transform.rotation);
                obstacleC = Instantiate(obstacle[2], spawnPoints[Random.Range(6, 9)].position, transform.rotation);
                break;
            case 2: // 길쭉한거 2개 양 옆 생성 작은거 한 개 중간 생성
                obstacleA = Instantiate(obstacle[0], spawnPoints[3].position, transform.rotation);
                obstacleB = Instantiate(obstacle[1], spawnPoints[FrontNum(1)].position, transform.rotation);
                obstacleC = Instantiate(obstacle[0], spawnPoints[5].position, transform.rotation);
                break;
            case 3: // 키 큰거 양 옆 생성 작은거 중간 생성 * 2
                obstacleA = Instantiate(obstacle[2], spawnPoints[6].position, transform.rotation);
                obstacleB = Instantiate(obstacle[1], spawnPoints[7].position, transform.rotation);
                obstacleC = Instantiate(obstacle[2], spawnPoints[8].position, transform.rotation);
                obstacleD = Instantiate(obstacle[2], spawnPoints[0].position, transform.rotation);
                obstacleE = Instantiate(obstacle[2], spawnPoints[1].position, transform.rotation);
                obstacleF = Instantiate(obstacle[1], spawnPoints[2].position, transform.rotation);
                break;
            case 4: // 중간 왼쪽 길쭉한거 오른쪽 작은거
                obstacleA = Instantiate(obstacle[0], spawnPoints[3].position, transform.rotation);
                obstacleB = Instantiate(obstacle[0], spawnPoints[4].position, transform.rotation);
                obstacleC = Instantiate(obstacle[1], spawnPoints[FrontNum(2)].position, transform.rotation);
                break;
            case 5: // 중간 왼쪽 길쭉한거 오른쪽 작은거
                obstacleA = Instantiate(obstacle[0], spawnPoints[3].position, transform.rotation);
                obstacleB = Instantiate(obstacle[0], spawnPoints[4].position, transform.rotation);
                obstacleC = Instantiate(obstacle[1], spawnPoints[FrontNum(2)].position, transform.rotation);
                break;
            case 6: // 길쭉한거 2개 양 옆 생성 작은거 한 개 중간 생성
                obstacleA = Instantiate(obstacle[0], spawnPoints[3].position, transform.rotation);
                obstacleB = Instantiate(obstacle[1], spawnPoints[FrontNum(1)].position, transform.rotation);
                obstacleC = Instantiate(obstacle[0], spawnPoints[5].position, transform.rotation);
                break;
            case 7: // 아무것도 없는거
                break;
        }
        

    }
    int FrontNum(int i) // 앞뒤로 숫자 바꿔줌
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
        Destroy(obstacleD);
        Destroy(obstacleE);
        Destroy(obstacleF);
    }
}
