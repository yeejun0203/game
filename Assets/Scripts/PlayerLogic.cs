using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public float dodgeSec;

    public float jumpHeight;

    [SerializeField]
    private GameObject wallCrashParti;

    // �÷��̾ ���� ������ true
    private bool ground;

    // �÷��̾� �̵� ���� �ʱⰪ
    private Vector3 dir = Vector3.zero;

    // ground üũ �� �� ���� ���̾�
    public LayerMask layer;

    Material playerMaterial;

    public bool isLive = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerMaterial = GetComponentInChildren<MeshRenderer>().material;
    }

    void Update()
    {
        // �÷��̾� �̵�
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
            else if (mySide == SIDE.Left)
            {
                Vector3 wallPos = new Vector3(-xValue - 1.5f, transform.position.y + 1.5f, transform.position.z);
                ObjectPool.SpawnObject(wallCrashParti, wallPos, wallCrashParti.transform.rotation);
                StartCoroutine(WallColor());
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
            else if (mySide == SIDE.Right)
            {
                Vector3 wallPos = new Vector3(xValue + 1.5f, transform.position.y + 1.5f, transform.position.z);
                ObjectPool.SpawnObject(wallCrashParti, wallPos, wallCrashParti.transform.rotation);
                StartCoroutine(WallColor());
            }
        }
        dir.z = GameManager.instance.gameLevel;

        // ���⼭ üũ
        GroundCheck();

        // �÷��̾ ���� �ְ� �����̽��ٸ� ������ ��
        if (Input.GetButtonDown("Jump") && ground)
        {
            // ���� �ø���
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rb.AddForce(jumpPower, ForceMode.VelocityChange);
        }

    }

    void FixedUpdate()
    {
        // ���� ��ġ �̵�
        if (!GameManager.instance.isGameStart) return;
        rb.DOMoveX(newXPos, dodgeSec).SetEase(Ease.OutQuint);
        rb.MovePosition(new Vector3(rb.position.x, rb.position.y, rb.position.z + dir.z * Time.fixedDeltaTime));
    }

    void GroundCheck()
    {
        // �÷��̾� �� �ؿ� ���� �ִ��� üũ
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 0.8f, layer))
        {
            ground = true;
        } else
        {
            ground = false;
        }
    }
    IEnumerator WallColor()
    {
        playerMaterial.color = Color.red;
        while (true)
        {
            playerMaterial.color = new Color(playerMaterial.color.r, playerMaterial.color.g + 0.02f, playerMaterial.color.b + 0.02f);
            yield return new WaitForEndOfFrame();
            if (playerMaterial.color == Color.white)
            {
                yield break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Obstacle")) return;

        // ��ֹ��̶� �ε�ġ�� ����Ǵ� �ڵ� (���⿡�ٰ� ü���� 0���� �۾����� ���� ���� �ǳ� ���� �ϼ�)
        GameManager.instance.health -= 20f;
        GameManager.instance.gameCamera.GetComponent<CameraShake>().ShakeCamera(5, 0.2f);
        if (GameManager.instance.health <= 0)
        {
            GameManager.instance.gameOverPanel.SetActive(true);
            ScoreManager.instance.SaveScore(GameManager.instance.gameScore);
            ScoreManager.instance.curScore = GameManager.instance.gameScore;
            GameManager.instance.gameLevel = 0;
            isLive = false;
            gameObject.SetActive(false);
        }
    }
}
