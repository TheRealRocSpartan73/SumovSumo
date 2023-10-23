using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody enemyRB;
    private GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>(); //Grab our RB object
        thePlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate the vector between enemy and player position
        //Normalise it so the enemy does not move faster if distance increases
        Vector3 lookDirection = (thePlayer.transform.position - this.transform.position).normalized;
        
        //Move the enemy towards the player.
        enemyRB.AddForce(lookDirection * speed);
    }
}
