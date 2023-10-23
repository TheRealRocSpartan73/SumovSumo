using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 3.0f;
    public bool hasPowerup = false; //No powerup at start

    private GameObject focalPoint;
    private Rigidbody playerRB;
    private float powerUpStrength = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); //Get the rigidBody component from the player object
        focalPoint = GameObject.Find("Focal Point"); //Reference to the Focal Point game object
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player collides with powerup, destroy the powerup object
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>(); //Ref to enemy Rigidbody component
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position; //Get vector pointing from player to enemy

            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse); //Send enemy bursting away from player.

            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
