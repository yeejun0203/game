using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    Rigidbody rb;

    public float jumpHeight;

    public float speed;

    // 플레이어가 땅에 있으면 true
    private bool ground;

    // 플레이어 이동 방향 초기값
    private Vector3 dir = Vector3.zero;

    // ground 체크 할 때 쓰는 레이어
    public LayerMask layer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 플레이어 이동
        dir.x = Input.GetAxisRaw("Horizontal") * speed;
        dir.z = GameManager.instance.gameLevel;

        // 여기서 체크
        GroundCheck();

        // 플레이어가 땅에 있고 스페이스바를 눌렀을때
        if (Input.GetButtonDown("Jump") && ground)
        {
            // 위로 올린다
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rb.AddForce(jumpPower, ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        // 실제 위치 이동
        if (!GameManager.instance.isGameStart) return;
        rb.MovePosition(transform.position + dir * Time.fixedDeltaTime);
    }

    void GroundCheck()
    {
        // 플레이어 발 밑에 땅이 있는지 체크
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 0.8f, layer))
        {
            ground = true;
        } else
        {
            ground = false;
        }
    }
}
