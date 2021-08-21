using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    private int waveNumber = 1;
    private int enemyCount;
    public GameObject enemyPrefab;
    private float spawnRange = 6.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<enemy>().Length;
        if(enemyCount == 0)
        {
            spawnEnemies(waveNumber++);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    void spawnEnemies(int spawns)
    {
        for (int i = 0; i < spawns; i++)
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
    Vector3 GenerateSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 2.5f, Random.Range(-spawnRange, spawnRange));
    }
}
