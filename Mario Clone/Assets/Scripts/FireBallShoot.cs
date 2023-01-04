using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShoot : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D fireBallRb;
    public Vector2 velocity;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        fireBallRb = GetComponent<Rigidbody2D>();
        playerController = GameObject.Find("Player_Fire(Clone)").GetComponent<PlayerController>();

        velocity = fireBallRb.velocity;
        StartCoroutine(WaitDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        if(fireBallRb.velocity.y < velocity.y)
        {
            fireBallRb.velocity = velocity;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fireBallRb.velocity = new Vector2(velocity.x, -velocity.y);

        // ÀûÀÌ¶û ¸¸³¯ ¶§ °°ÀÌ ¼Ò¸êÇÑ´Ù
        if(collision.gameObject.tag == "Enemy")
        {
            playerController.fireBallCnt--;
            Destroy(collision.gameObject);
        }

        // º®ÀÌ¶û ¸¸³ª¸é Æø¹ß
        if(collision.contacts[0].normal.x !=0)
        {
            playerController.fireBallCnt--;
            Destroy(gameObject);
        }
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(5);
        playerController.fireBallCnt--;
        Destroy(gameObject);
    }
}
