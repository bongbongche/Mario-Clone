using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManage : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.UpdateScore();
        if(collision.gameObject.tag == "Player_Fire" || collision.gameObject.tag == "Player_Big" || collision.gameObject.tag == "Player_Mini")
        {
            Destroy(gameObject);
        }
    }
}
