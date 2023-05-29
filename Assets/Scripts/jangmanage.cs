using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jangmanage : MonoBehaviour
{
    public GameObject rangeObject;
    public GameObject capsul;
    public float zSpawn = 35;
    public int numberOfTiles = 40;
    public float tileLength = 50f;
    public List<GameObject> activeTiles = new List<GameObject>();
    BoxCollider rangeCollider;
    

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    private void Update()
    {
        // 플레이어 위치에 따른 땅 생성 및 삭제
        if (GameManager.instance.player.transform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            
            Deletejang();
        }
    }

    /*private void spawnjang()
    {
        //StartCoroutine(RandomRespawn_Coroutine());
            //StartCoroutine(RandomRespawn_Coroutine());
        GameObject instantCapsul = Instantiate(capsul, Return_RandomPosition(), Quaternion.identity);
        instantCapsul.transform.parent = gameObject.transform;
        activeTiles.Add(instantCapsul);
        zSpawn += tileLength;
    }*/

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            GameObject instantCapsul = Instantiate(capsul, Return_RandomPosition(), Quaternion.identity);
            //instantCapsul.transform.parent = gameObject.transform;
            activeTiles.Add(instantCapsul);
            zSpawn += tileLength;
        }
    }
    

    void Deletejang()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}