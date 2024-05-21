using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner3 : MonoBehaviour
{
    
    public GameObject enemyPrefab;

    
    private Vector2[] area1 = {
        
    };

    
    public int maxEnemies = 10;

    
    private void SpawnEnemy()
    {
        
        float randomX = Random.Range(-20.0f, 20.0f);
        float randomY = Random.Range(-14.0f, 16.0f);

        
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    
    void Start()
    {
        
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }
}
