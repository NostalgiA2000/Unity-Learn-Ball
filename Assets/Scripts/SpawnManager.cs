using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpwanEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition() + new Vector3(0, 0.339f ,0), powerupPrefab.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + new Vector3(0, 0.339f, 0), powerupPrefab.transform.rotation);
            waveNumber++;
            SpwanEnemyWave(waveNumber);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpwanEnemyWave(int enemiesToSpwan)
    {
        for (int i = 0; i < enemiesToSpwan; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
