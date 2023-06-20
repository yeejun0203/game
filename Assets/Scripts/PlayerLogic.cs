using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Mid, Right }
public class PlayerLogic : MonoBehaviour
{
    Rigidbody rb;

    [Header("### Moving Logic")]
    public SIDE mySide = SIDE.Mid;
    private bool leftClick, rightClick;

    private float newXPos = 0f;
    public float xValue;

    public float dodgeSpeed;
    private float x;

    public float jumpHeight;

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
        leftClick = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        rightClick = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        if (leftClick)
        {
            if (mySide == SIDE.Mid)
            {
                newXPos = -xValue;
                mySide = SIDE.Left;
            }
            else if (mySide == SIDE.Right)
            {
                newXPos = 0;
                mySide = SIDE.Mid;
            }
        }
        else if (rightClick)
        {
            if (mySide == SIDE.Mid)
            {
                newXPos = xValue;
                mySide = SIDE.Right;
            }
            else if (mySide == SIDE.Left)
            {
                newXPos = 0;
                mySide = SIDE.Mid;
            }
        }
        dir.z = GameManager.instance.gameLevel;

        // 여기서 체크
        GroundCheck();

        // 플레이어가 땅에 있고 스페이스바를 눌렀을 때
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
        x = Mathf.Lerp(x, newXPos, Time.fixedDeltaTime * dodgeSpeed);
        rb.MovePosition(new Vector3(x, transform.position.y, transform.position.z + dir.z * Time.fixedDeltaTime));
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
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Obstacle")) return;

        // 장애물이랑 부딪치면 실행되는 코드 (여기에다가 체력이 0보다 작아지면 게임 오버 판넬 띄우게 하셈)

        GameManager.instance.health -= 20f;
        GameManager.instance.gameCamera.GetComponent<CameraShake>().ShakeCamera(5, 0.2f);
    }
}
