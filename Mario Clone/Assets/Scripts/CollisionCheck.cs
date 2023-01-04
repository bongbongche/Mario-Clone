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
        // ������ ���� ������ �� ����
        if(collision.gameObject.tag == "Enemy" && playerController.isBig == false)
        {
            Debug.Log("body");
            Destroy(transform.parent.gameObject);
        }

        // ū�� ���� ������ �� �۾���.
        else if (collision.gameObject.tag == "Enemy" && playerController.isBig == true)
        {
            Instantiate(transform.parent.GetComponent<PlayerController>().playerBig, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }

        // ���̾��ε� ���� ������ �� �׳� ū �ɷ�.
        else if (collision.gameObject.tag == "Enemy" && playerController.isFire == true)
        {
            Instantiate(transform.parent.GetComponent<PlayerController>().playerBig, transform.position, transform.rotation);
            playerController.isBig = true;
            Destroy(transform.parent.gameObject);
        }
    }
}
