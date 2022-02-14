using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnForward : MonoBehaviour
{
    PlayerMove player;
    int numberBlock = 7;
    public bool bRespawn;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        bRespawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distX = transform.position.x - player.transform.position.x;
        if (distX < -(numberBlock + player.originalPositionX))
        {
            transform.position = new Vector3((float)(transform.position.x + numberBlock * 2), transform.position.y, transform.position.z);
            bRespawn = true;
        }
    }
}
