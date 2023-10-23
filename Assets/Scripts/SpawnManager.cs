using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f; //Range from origin for randoms
    // Start is called before the first frame update
    void Start()
    {
        //Create enemies based on wave variable
        SpawnEnemyWave(3);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //Create enemy sphere.
            Instantiate(enemyPrefab, this.GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        //Grab a random X and Y co-ordinate
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        //Create a new Vector based on the random's
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}