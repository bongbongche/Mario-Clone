using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManage : MonoBehaviour
{
    public SpriteRenderer imgRenderer;
    public Sprite sprite01;
    public GameObject item;
    public bool isItemOn = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeImage()
    {
        imgRenderer.sprite = sprite01;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Mystery Block" && isItemOn == false && collision.gameObject.tag == "Player_Mini")
        {
            isItemOn = true;
            Instantiate(item, transform.position + new Vector3(0, 0.15f, 0), transform.rotation);
        }
    }
}
