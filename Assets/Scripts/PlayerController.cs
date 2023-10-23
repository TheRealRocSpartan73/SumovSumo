using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); //Get the rigidBody component from the player object
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(Vector3.forward * forwardInput * speed);
    }
}
