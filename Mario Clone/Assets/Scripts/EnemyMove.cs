using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    public PlayerController playerController;
    public float enemySpeed = 1.0f;
    public Vector2 direction = new Vector2(-1, 0);

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 전진
        transform.Translate(direction * enemySpeed * Time.deltaTime);
    }

    // 충돌하면 방향 바꿔서 전진
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !playerController.isOnGround)
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player" && playerController.isOnGround)
        {
            Destroy(collision.gameObject);
        }

        direction =  (-1) * direction;
    }
}
