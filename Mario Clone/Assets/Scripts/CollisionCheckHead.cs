using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckHead : MonoBehaviour
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
        if (collision.gameObject.tag == "Normal Block" && playerController.isBig == true)
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Mystery Block")
        {
            collision.gameObject.GetComponent<BlockManage>().ChangeImage();
        }
    }
}
