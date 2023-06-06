using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    Rigidbody rb;

    public float jumpHeight;

    public float speed;

    // �÷��̾ ���� ������ true
    private bool ground;

    // �÷��̾� �̵� ���� �ʱⰪ
    private Vector3 dir = Vector3.zero;

    // ground üũ �� �� ���� ���̾�
    public LayerMask layer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �÷��̾� �̵�
        dir.x = Input.GetAxisRaw("Horizontal") * speed;
        dir.z = GameManager.instance.gameLevel;

        // ���⼭ üũ
        GroundCheck();

        // �÷��̾ ���� �ְ� �����̽��ٸ� ��������
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
        rb.MovePosition(transform.position + dir * Time.fixedDeltaTime);
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
}
