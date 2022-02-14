using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    // position Y
    public float posMinY = -3f;
    public float posMaxY = 3f;
    SpawnForward spawn;
    PlayerMove player;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        RandomY();
        spawn = GetComponent<SpawnForward>();
        player = FindObjectOfType<PlayerMove>();
        speed = player.GetComponent<MoveForward>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn.bRespawn)
        {
            RandomY();
            spawn.bRespawn = false;
        }

        if (GameManager.instance.state == GameManager.State.Title)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void RandomY()
    {
        // random position Y
        float random = Random.Range(posMinY, posMaxY);
        transform.position = new Vector3(transform.position.x, random, transform.position.z);
    }
}
