using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody mRigidbody;
    // Fly
    public int forceFly = 250;
    // original position
    public float originalPositionX;
    // get score
    bool isEntered;
    // text to fly
    public GameObject textFly;
    // rotation
    float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        originalPositionX = transform.position.x;
        isEntered = false;
        rotZ = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fly();
        }

        // game over
        if (GameManager.instance.state == GameManager.State.GameOver)
        {
            // rotate -90 degree
            if (rotZ > -90f) rotZ -= Time.deltaTime * 400;
            transform.rotation = Quaternion.Euler(new Vector3(0f,0f,rotZ));
        }
    }

    public void Fly()
    {
        if (GameManager.instance.state == GameManager.State.Play)
        {
            // fly
            mRigidbody.velocity = new Vector3(mRigidbody.velocity.x, 0f, 0f);
            mRigidbody.AddForce(new Vector3(0, forceFly, 0));
            // sound
            SoundManager.instance.PlaySound(SoundManager.instance.audioJump, transform.position, 1f);
            // text fly
            textFly.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isEntered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // get score
        //print("Scored");
        if (isEntered)
        {
            GameManager.instance.AddScore();
            isEntered = false;
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Game Over
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pole"))
        {
            if (GameManager.instance.state == GameManager.State.Play)
            {
                GameManager.instance.GameOver();
            }
        } 
    }
}
