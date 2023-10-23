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
        //Move the enemy towards the player. Once the direction is calculated, normalise the vector
        //so that the Vector does not increase due to distance from enemy.
        enemyRB.AddForce((thePlayer.transform.position - this.transform.position).normalized * speed);
    }
}
