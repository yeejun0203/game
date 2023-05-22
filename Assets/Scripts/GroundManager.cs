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

    private void Start()
    {
        //�ʱ� �� ���� ����
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }
    private void Update()
    {
        // �÷��̾� ��ġ�� ���� �� ���� �� ����
        if(GameManager.instance.player.transform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    /**
     ���� �����մϴ�
     */
    public void SpawnTile()
    {
        // go��� �� ����
        GameObject go = Instantiate(tilePrefabs, transform.forward * zSpawn, transform.rotation);
        go.transform.parent = gameObject.transform;
        activeTiles.Add(go); // ���� ����Ʈ�� �߰�
        zSpawn += tileLength; // �� z�ʱ�ȭ
    }
    /**
     * ���� �����մϴ�
     **/
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}