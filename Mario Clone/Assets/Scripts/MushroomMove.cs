using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMove : MonoBehaviour
{
    public float enemySpeed = 1.0f;
    public Vector2 direction = new Vector2(-1, 0);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 전진
        transform.Translate(direction * enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player_Mini" || collision.gameObject.tag == "Player_Big")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Wall")
        {
            // 충돌하면 방향 바꿔서 전진
            direction = (-1) * direction;
        }
    }
}
