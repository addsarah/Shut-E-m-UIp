using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;  
    public Transform spawnArea;          
    public float spawnInterval = 3f;      
    public int minEnemies = 1;
    public int maxEnemies = 3;
    
    public float minSpawnDistance = 3f;

    private float timer;
    public static EnemySpawner instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemies();
            timer = 0f;
        }
    }

    void SpawnEnemies()
    {
        int count = Random.Range(minEnemies, maxEnemies + 1);
        List<Vector2> spawnedPositions = new List<Vector2>();

        for (int i = 0; i < count; i++)
        {
            Vector2 spawnPos = GetNonOverlappingRandomPoint(spawnedPositions);
            spawnedPositions.Add(spawnPos);
            
            int index = Random.Range(0, enemyPrefabs.Count);
            GameObject selectedEnemy = enemyPrefabs[index];

            Instantiate(selectedEnemy, spawnPos, Quaternion.identity);
        }
    }
    
    Vector2 GetNonOverlappingRandomPoint(List<Vector2> existingPositions)
    {
        Vector2 newPos;
        int maxAttempts = 50;
        int attempts = 0;

        while (attempts < maxAttempts)
        {
            newPos = GetRandomPointInArea();
            bool isOverlapping = false;
            foreach (Vector2 pos in existingPositions)
            {
                if (Vector2.Distance(newPos, pos) < minSpawnDistance)
                {
                    isOverlapping = true;
                    break;
                }
            }

            if (!isOverlapping)
            {
                return newPos;
            }
            attempts++;
        }
        return GetRandomPointInArea();
    }
    
    Vector2 GetRandomPointInArea()
    {
        Vector3 areaPos = spawnArea.position;
        Vector3 areaSize = spawnArea.localScale;

        float x = Random.Range(areaPos.x - areaSize.x / 2f, areaPos.x + areaSize.x / 2f);
        float y = areaPos.y;

        return new Vector2(x, y);
    }
    public void IncreaseMaxEnemies()
    {
        maxEnemies++;
        Debug.Log("Max enemies increased to: " + maxEnemies);
    }
}