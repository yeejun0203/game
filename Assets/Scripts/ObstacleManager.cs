using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacle; // 0�� �����Ѱ� 1�� ������ 2�� Ű ū��
    public List<Transform> spawnPoints; // ���� ������ 0 1 2 ...
    public bool isStart;

    private GameObject[] obstacles;
    int random;

    private void Start()
    {
        obstacles = new GameObject[1];
        if (isStart)
        {
            random = 9;
        } else
        {
            random = Random.Range(0, 10);
        }
        GenerateObstacle(random);
    }

    void GenerateObstacle(int randomNum)
    {
        switch (randomNum)
        {
            case 0: // Ű ū�� 2�� ������ �߰� 3��
                obstacles = new GameObject[5];

                obstacles[0] = Instantiate(obstacle[2], spawnPoints[Random.Range(0, 3)].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[1], spawnPoints[3].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[1], spawnPoints[4].position, transform.rotation);
                obstacles[3] = Instantiate(obstacle[1], spawnPoints[5].position, transform.rotation);
                obstacles[4] = Instantiate(obstacle[2], spawnPoints[Random.Range(6, 9)].position, transform.rotation);
                break;
            case 1: // Ű ū�� 2�� ������ �߰� 3��
                obstacles = new GameObject[5];

                obstacles[0] = Instantiate(obstacle[2], spawnPoints[Random.Range(0, 3)].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[1], spawnPoints[3].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[1], spawnPoints[4].position, transform.rotation);
                obstacles[3] = Instantiate(obstacle[1], spawnPoints[5].position, transform.rotation);
                obstacles[4] = Instantiate(obstacle[2], spawnPoints[Random.Range(3, 6)].position, transform.rotation);
                break;
            case 2: // Ű ū�� �� �� ���� ������ �߰� ���� * 3
                obstacles = new GameObject[8];

                obstacles[0] = Instantiate(obstacle[2], spawnPoints[6].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[2], spawnPoints[8].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[2], spawnPoints[0].position, transform.rotation);
                obstacles[3] = Instantiate(obstacle[2], spawnPoints[1].position, transform.rotation);
                obstacles[4] = Instantiate(obstacle[1], spawnPoints[2].position, transform.rotation);
                obstacles[5] = Instantiate(obstacle[1], spawnPoints[3].position, transform.rotation);
                obstacles[6] = Instantiate(obstacle[2], spawnPoints[4].position, transform.rotation);
                obstacles[7] = Instantiate(obstacle[2], spawnPoints[5].position, transform.rotation);
                break;
            case 3: // Ű ū�� �� �� ���� ������ �߰� ���� * 3
                obstacles = new GameObject[8];

                obstacles[0] = Instantiate(obstacle[2], spawnPoints[6].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[2], spawnPoints[8].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[2], spawnPoints[0].position, transform.rotation);
                obstacles[3] = Instantiate(obstacle[2], spawnPoints[1].position, transform.rotation);
                obstacles[4] = Instantiate(obstacle[1], spawnPoints[2].position, transform.rotation);
                obstacles[5] = Instantiate(obstacle[1], spawnPoints[3].position, transform.rotation);
                obstacles[6] = Instantiate(obstacle[2], spawnPoints[4].position, transform.rotation);
                obstacles[7] = Instantiate(obstacle[2], spawnPoints[5].position, transform.rotation);
                break;
            case 4: // �߰� ���� �����Ѱ� ������ ������
                obstacles = new GameObject[3];

                obstacles[0] = Instantiate(obstacle[0], spawnPoints[3].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[0], spawnPoints[4].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[1], spawnPoints[FrontNum(2)].position, transform.rotation);
                break;
            case 5: // Ű ū�� �� �� ���� ������ �߰� ���� * 3
                obstacles = new GameObject[8];

                obstacles[0] = Instantiate(obstacle[2], spawnPoints[6].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[1], spawnPoints[7].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[2], spawnPoints[8].position, transform.rotation);
                obstacles[3] = Instantiate(obstacle[2], spawnPoints[0].position, transform.rotation);
                obstacles[4] = Instantiate(obstacle[2], spawnPoints[1].position, transform.rotation);
                obstacles[5] = Instantiate(obstacle[1], spawnPoints[3].position, transform.rotation);
                obstacles[6] = Instantiate(obstacle[2], spawnPoints[4].position, transform.rotation);
                obstacles[7] = Instantiate(obstacle[2], spawnPoints[5].position, transform.rotation);
                break;
            case 6: // �����Ѱ� 1�� �� �� ���� ������ �� �� ����
                obstacles = new GameObject[5];

                obstacles[0] = Instantiate(obstacle[0], spawnPoints[3].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[2], spawnPoints[7].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[1], spawnPoints[8].position, transform.rotation);
                obstacles[3] = Instantiate(obstacle[2], spawnPoints[2].position, transform.rotation);
                obstacles[4] = Instantiate(obstacle[1], spawnPoints[3].position, transform.rotation);
                break;
            case 7: // Ű ū�� 2�� ���� ���� ������ �� �� ���� ����
                obstacles = new GameObject[3];

                obstacles[0] = Instantiate(obstacle[2], spawnPoints[Random.Range(0, 3)].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[1], spawnPoints[Random.Range(3, 6)].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[2], spawnPoints[Random.Range(6, 9)].position, transform.rotation);
                break;
            case 8: // �����Ѱ� �߰� ������ ���� �� �� �� ��
                obstacles = new GameObject[3];

                obstacles[0] = Instantiate(obstacle[0], spawnPoints[4].position, transform.rotation);
                obstacles[1] = Instantiate(obstacle[1], spawnPoints[FrontNum(0)].position, transform.rotation);
                obstacles[2] = Instantiate(obstacle[1], spawnPoints[FrontNum(2)].position, transform.rotation);

                break;
            case 9: // �ƹ��͵� ���°�
                break;
        }
        if (obstacles.Length <= 1) return; 
        foreach (GameObject i in obstacles)
        {
            i.transform.parent = gameObject.transform;
        }

    }
    int FrontNum(int i) // �յڷ� ���� �ٲ���
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
}
