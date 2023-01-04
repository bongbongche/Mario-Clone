using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinImage : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.UpdateScore();
        Destroy(gameObject, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
