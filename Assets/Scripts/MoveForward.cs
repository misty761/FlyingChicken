using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // player
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // no game over
            if (GameManager.instance.state != GameManager.State.GameOver)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            } 
        }
        // others
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        */

        // no game over
        if (GameManager.instance.state != GameManager.State.GameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }
}
