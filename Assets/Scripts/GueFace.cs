using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GueFace : MonoBehaviour
{
    // 0 common gue, 1 happy gue, 2 sad gue
    public List<Sprite> gueFaces = new List<Sprite>();

    SpriteRenderer spriter;

    private void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating("FaceChange", 2, 2);
    }
    private void Update()
    {
        if (GameManager.instance.player.GetComponent<PlayerLogic>().isLive == false)
        {
            CancelInvoke();
            spriter.sprite = gueFaces[2];
        }
    }

    private void FaceChange()
    {
        if (spriter.sprite == gueFaces[0])
        {
            spriter.sprite = gueFaces[1];
        }
        else if (spriter.sprite == gueFaces[1])
        {
            spriter.sprite = gueFaces[0];
        }
    }
}
