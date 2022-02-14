using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int rotateSpeedY = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.state != GameManager.State.GameOver)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -rotateSpeedY * Time.time, 0));
        }
    }    
}
