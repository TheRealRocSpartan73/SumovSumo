using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber = 1; //Track number of waves
    

    private float spawnRange = 9.0f; //Range from origin for randoms

    // Start is called before the first frame update
    void Start()
    {
        //Create enemies based on waveNumber variable
        SpawnEnemyWave(waveNumber);
        //Create an initial powerup
        SpawnPowerUp();

    }

    // Update is called once per frame
    void Update()
    {
        //How many enemies have we ?
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0) //All Enemies have gone
        {
            waveNumber++; //Move to the next wave
            SpawnEnemyWave(waveNumber);  //Spawn some more bad guys based on wave
            //Create an new powerup
            SpawnPowerUp();
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //Create enemy sphere.
            Instantiate(enemyPrefab, this.GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUp()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
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