using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int spawnCount = 1;
    
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(spawnCount);
        Instantiate(powerupPrefab, GenerateRandomPos(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            spawnCount++;
            SpawnEnemyWave(spawnCount);
            Instantiate(powerupPrefab, GenerateRandomPos(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int spawn)
    {
        for (int i = 0; i < spawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
        }        
    }

    private Vector3 GenerateRandomPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return spawnPos;
    }
}
