using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemies;

    // Probability of spawned enemy to be a melee
    public float meleeProbability = 0.5f;


    // Time to spawn enemy
    public float spawnTime = 5.0f;

    // Last time of spawn
    public float previousSpawnTime = 0.0f;

    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(previousSpawnTime >= spawnTime)
        {
            if (Random.Range(0.0f, 1.0f) <= meleeProbability)
            {
                GameObject project = Instantiate(enemies[0], spawnPoint.position,
                                spawnPoint.rotation);
            }
            else
            {
                GameObject project = Instantiate(enemies[1], spawnPoint.position,
                                spawnPoint.rotation);
            }
            previousSpawnTime = 0.0f;
        }
        else
        {
            previousSpawnTime += Time.deltaTime;
            
        }
        
    }
}
