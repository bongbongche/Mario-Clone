using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;

    public float hInput;
    public float speed = 5.0f;
    public float maxSpeed = 30.0f;
    public float jumpForce = 5.0f;

    public bool isLongJump = false;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
            Jump();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}
