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
        // 새로 생성됐는데 클 때
        if(gameObject.tag == "Player_Big")
        {
            isBig = true;
        }
        // 새로 생성됐는데 파이어일 때
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

        // 좌우 움직임
        playerRb.AddForce(Vector2.right * hInput * speed * Time.deltaTime, ForceMode2D.Impulse);

        // 속도 제한
        if(playerRb.velocity.x > maxSpeed)
        {
            playerRb.velocity = new Vector2(maxSpeed, playerRb.velocity.y);
        }
        else if(playerRb.velocity.x < -maxSpeed)
        {
            playerRb.velocity = new Vector2(-maxSpeed, playerRb.velocity.y);
        }

        // 점프
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

        // 플레이어가 바라보는 방향에 따라 캐릭터 좌우 변경
        if (hInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (hInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // 파이어볼 발사
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
        // W 꾹 누르면 점프 높이 조절
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

        // 버섯먹었을 때
        if(collision.gameObject.tag == "Mushroom" && !isBig)
        {
            isBig = true;
            Instantiate(playerBig, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        // 꽃 먹었을 때
        if(collision.gameObject.tag == "Fire Flower" && !isFire)
        {
            isFire = true;
            Instantiate(playerFire, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
