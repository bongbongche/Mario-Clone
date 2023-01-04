using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    private Transform player;

    public float height = 13.96f;
    public float undergroundHeight = 11.38f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player_Mini"))
        {
            player = GameObject.FindWithTag("Player_Mini").transform;
        }
        else if(GameObject.FindWithTag("Player_Big"))
        {
            player = GameObject.FindWithTag("Player_Big").transform;
        }
        else if (GameObject.FindWithTag("Player_Fire"))
        {
            player = GameObject.FindWithTag("Player_Fire").transform;
        }

        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
        transform.position = cameraPosition;
    }

    public void SetUnderground(bool isUnderground)
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = isUnderground ? undergroundHeight : height;
        transform.position = cameraPosition;
    }
}
