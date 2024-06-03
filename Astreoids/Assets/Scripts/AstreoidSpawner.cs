using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnRate = 2f;
    
    private float spawnDistance = 12f;
    private int j = 0;
    
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, spawnRate);
    }

    private void Spawn()
    {
        j++;
        Debug.Log(j);
        if(j==20){
            SpawnAstreoids(16);
        }
        else if(j==40){
            SpawnAstreoids(20, 1f, 1.5f);
        }
        else if(j==60){
            SpawnAstreoids(26, 1.2f, 2f, 1.5f);
        }
        else if(j==80){
            SpawnAstreoids(50, 1.2f, 2f, 1.5f);
        }
        else if(j>60){
            SpawnAstreoids(3, 1.2f, 2.5f, 1.5f);
        }
        else if(j>=50){
            SpawnAstreoids(3, 1.2f, 2f);
        }
        else if(j>=25){
            SpawnAstreoids(2, 1.2f, 1.5f);
        }
        else{
            SpawnAstreoids();
        }
    }


    void SpawnAstreoids(int amount = 1, float distance = 1f, float sizeUpgrade = 1f, float astreoidSpeed = 1f){
        for(int i = 0; i < amount; i++)
            {
                Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance * distance;
                Vector3 spawnPoint = transform.position + spawnDirection;

                Quaternion rotation = Quaternion.AngleAxis(Random.Range(-12f,12f), Vector3.forward);

                Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
                asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize * sizeUpgrade);
                asteroid.SetForce(rotation * -spawnDirection * astreoidSpeed);
            }
    }
}
