using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 작은데 적을 만났을 때 죽음
        if(collision.gameObject.tag == "Enemy" && playerController.isBig == false)
        {
            Debug.Log("body");
            Destroy(transform.parent.gameObject);
        }

        // 큰데 적을 만났을 때 작아짐.
        else if (collision.gameObject.tag == "Enemy" && playerController.isBig == true)
        {
            Instantiate(transform.parent.GetComponent<PlayerController>().playerBig, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }

        // 파이어인데 적을 만났을 때 그냥 큰 걸로.
        else if (collision.gameObject.tag == "Enemy" && playerController.isFire == true)
        {
            Instantiate(transform.parent.GetComponent<PlayerController>().playerBig, transform.position, transform.rotation);
            playerController.isBig = true;
            Destroy(transform.parent.gameObject);
        }
    }
}
