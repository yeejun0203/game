/*
 * �ȳ��ϼ���*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    // �� ������
    public GameObject tilePrefabs;
    // ���� �����Ǵ� Z��ġ
    public float zSpawn = 0;
    // �� ����
    public float tileLength = 16f;
    // �ʱ� �����Ǵ� �� ����
    public int numberOfTiles = 10;
    // ������ ���� ��Ƴ��� ����Ʈ
    public List<GameObject> activeTiles = new List<GameObject>();

    public int currentTileNum = 0;

    private void Start()
    {
        //�ʱ� �� ���� ����
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
            currentTileNum++;
        }
    }
    private void Update()
    {
        // �÷��̾� ��ġ�� ���� �� ���� �� ����
        if (GameManager.instance.player.GetComponent<PlayerLogic>().isLive == false) return;
        if(GameManager.instance.player.transform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    /**
     ���� �����մϴ�
     */
    private void SpawnTile()
    {
        // go��� �� ����
        GameObject go = ObjectPool.SpawnObject(tilePrefabs, transform.forward * zSpawn, transform.rotation);
        if (currentTileNum > 1)
        {
            go.GetComponent<ObstacleManager>().isStart = false;
        }
        go.transform.parent = gameObject.transform;
        activeTiles.Add(go); // ���� ����Ʈ�� �߰�
        zSpawn += tileLength; // �� z�ʱ�ȭ
    }
    /**
     * ���� �����մϴ�
     **/
    void DeleteTile()
    {
        if (activeTiles[0].GetComponent<ObstacleManager>().isStart == false)
        {
            GameManager.instance.gameScore += 100;
        }
        ObjectPool.ReturnObjectToPool(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
