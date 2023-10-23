using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 1.5f;
    public bool hasPowerup = false; //No powerup at start
    public GameObject powerupIndicator;

    private GameObject focalPoint;
    private Rigidbody playerRB;
    private float powerUpStrength = 25.0f;
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

        //Move the powerup indicator with the player object and lower it a tad on Y axis.
        powerupIndicator.transform.position = this.transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player collides with powerup, destroy the powerup object
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);//Turn on the attached powerup
            Destroy(other.gameObject);//Remove the powerup

            //Start a timer that will wait for 7 seconds, then reset the powerup boolean
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    //Creates a new 7 second timer outside of the main update loop
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerupIndicator.gameObject.SetActive(false);//Turn off the attached powerup
        hasPowerup = false;
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
