/*
 * 안녕하세요*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    // 땅 프리펩
    public GameObject tilePrefabs;
    // 현재 생성되는 Z위치
    public float zSpawn = 0;
    // 땅 길이
    public float tileLength = 16f;
    // 초기 생성되는 땅 개수
    public int numberOfTiles = 10;
    // 생성된 땅을 담아놓은 리스트
    public List<GameObject> activeTiles = new List<GameObject>();

    public int currentTileNum = 0;

    private void Start()
    {
        //초기 땅 생성 로직
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
            currentTileNum++;
        }
    }
    private void Update()
    {
        // 플레이어 위치에 따른 땅 생성 및 삭제
        if (GameManager.instance.player.GetComponent<PlayerLogic>().isLive == false) return;
        if(GameManager.instance.player.transform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    /**
     땅을 생성합니다
     */
    private void SpawnTile()
    {
        // go라는 땅 생성
        GameObject go = ObjectPool.SpawnObject(tilePrefabs, transform.forward * zSpawn, transform.rotation);
        if (currentTileNum > 1)
        {
            go.GetComponent<ObstacleManager>().isStart = false;
        }
        go.transform.parent = gameObject.transform;
        activeTiles.Add(go); // 땅을 리스트에 추가
        zSpawn += tileLength; // 땅 z초기화
    }
    /**
     * 땅을 삭제합니다
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
