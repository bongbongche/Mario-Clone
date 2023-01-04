using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Transform connection;
    private CameraScrolling cameraScrolling;
    public bool isUnderground = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraScrolling = GameObject.Find("Main Camera").GetComponent<CameraScrolling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Debug.Log(connection.position.y);
            isUnderground = connection.position.y < 12f;
            Debug.Log(isUnderground);
            collision.transform.parent.position = connection.position;
            cameraScrolling.SetUnderground(isUnderground);
        }
    }

}
