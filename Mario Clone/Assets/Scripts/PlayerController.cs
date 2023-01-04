using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private FireFlower fireFlower;

    public GameObject playerBig;
    public GameObject playerFire;
    public GameObject fireBall;
    public Vector2 fireBallVelocity;
    public Vector2 offset = new Vector2(0.1f, 0.1f);

    public float hInput;
    public float speed = 5.0f;
    public float maxSpeed = 30.0f;
    public float jumpForce = 5.0f;
    public int direction;
    public int fireBallCnt = 0;
    public Vector2 playerVelocity;

    public bool isLongJump = false;
    public bool isOnGround = true;
    public bool isBig = false;
    public bool isFire = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        // ���� �����ƴµ� Ŭ ��
        if(gameObject.tag == "Player_Big")
        {
            isBig = true;
        }
        // ���� �����ƴµ� ���̾��� ��
        if(gameObject.tag == "Player_Fire")
        {
            isBig = true;
            isFire = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y);

        hInput = Input.GetAxis("Horizontal");

        // �¿� ������
        playerRb.AddForce(Vector2.right * hInput * speed * Time.deltaTime, ForceMode2D.Impulse);

        // �ӵ� ����
        if(playerRb.velocity.x > maxSpeed)
        {
            playerRb.velocity = new Vector2(maxSpeed, playerRb.velocity.y);
        }
        else if(playerRb.velocity.x < -maxSpeed)
        {
            playerRb.velocity = new Vector2(-maxSpeed, playerRb.velocity.y);
        }

        // ����
        if(Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if(Input.GetKey(KeyCode.W))
        {
            isLongJump = true;
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            isLongJump = false;
        }

        // �÷��̾ �ٶ󺸴� ���⿡ ���� ĳ���� �¿� ����
        if (hInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (hInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // ���̾ �߻�
        if(Input.GetKeyDown(KeyCode.RightShift) && isFire && fireBallCnt < 2)
        {
            fireBallCnt++;
            if (transform.rotation.y == 0)
            {
                GameObject go = (GameObject)Instantiate(fireBall, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(fireBallVelocity.x * transform.localScale.x, fireBallVelocity.y);
            }
            else
            {
                GameObject go = (GameObject)Instantiate(fireBall, (Vector2)transform.position + new Vector2(-offset.x, offset.y) * transform.localScale.x, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireBallVelocity.x * transform.localScale.x, fireBallVelocity.y);
            }
        }
    }

    private void FixedUpdate()
    {
        // W �� ������ ���� ���� ����
        if(isLongJump && playerRb.velocity.y > 0)
        {
            playerRb.gravityScale = 1.0f;
        }
        else
        {
            playerRb.gravityScale = 2.5f;
        }
    }

    private void Jump()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, 1 * jumpForce);
        //playerRb.AddForce(Vector2.up * jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;

        // �����Ծ��� ��
        if(collision.gameObject.tag == "Mushroom" && !isBig)
        {
            isBig = true;
            Instantiate(playerBig, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        // �� �Ծ��� ��
        if(collision.gameObject.tag == "Fire Flower" && !isFire)
        {
            isFire = true;
            Instantiate(playerFire, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
