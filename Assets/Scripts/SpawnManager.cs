// This code is based on from Create With Code Series:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] keyPrefabs;
    public int numberOfKeys = 6;
    public int numberOfEnemies = 4;

    private Vector3[] spawnPoints = new Vector3[]
    {
        new Vector3(11.79f, -1.872f, 0.7969513f),
       
    };

    private GameObject[] spawnedKeys;
    private GameObject[] spawnedEnemies;

    void Start()
    {
        spawnedKeys = new GameObject[numberOfKeys];
        spawnedEnemies = new GameObject[numberOfEnemies];
        SpawnKeys();
        SpawnEnemies();
    }

    void SpawnKeys()
    {
        for (int i = 0; i < numberOfKeys; i++)
        {
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject keyPrefab = keyPrefabs[Random.Range(0, keyPrefabs.Length)];
            spawnedKeys[i] = Instantiate(keyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            spawnedEnemies[i] = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

