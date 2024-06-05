using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] keyPrefabs;
    public int numberOfKeys = 3;
    public int numberOfEnemies = 4;

    private Vector3[] spawnPoints = new Vector3[]
    {
        new Vector3(-45.265f, 24.98f, 64.531f),
        new Vector3(-30.45874f, 25.00671f, 64.25317f),
        new Vector3(-42.56873f, 25.00671f, 64.25317f)
    };

    private GameObject[] spawnedKeys;
    private GameObject[] spawnedEnemies;

    void Start()
    {
        spawnedKeys = new GameObject[numberOfKeys];
        spawnedEnemies = new GameObject[numberOfEnemies];
        SpawnKeys();
        SpawnEnemies();
        DeactivateSpawnedObjects();
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

    void DeactivateSpawnedObjects()
    {
        foreach (GameObject key in spawnedKeys)
        {
            if (key != null)
            {
                key.SetActive(false);
            }
        }

        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                enemy.SetActive(false);
            }
        }
    }

    public void ActivateSpawnedObjects()
    {
        foreach (GameObject key in spawnedKeys)
        {
            if (key != null)
            {
                key.SetActive(true);
            }
        }

        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                enemy.SetActive(true);
            }
        }
    }
}
