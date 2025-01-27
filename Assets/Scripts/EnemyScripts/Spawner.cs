using System.IO;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemySpawn;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float spawnTimer;
    [SerializeField] int spawnCount;
    private float currentSpawnTimer;

    private void Update()
    {
        if (spawnCount != 0)
        {
            currentSpawnTimer -= Time.deltaTime;
            if (currentSpawnTimer <= 0)
            {
                Instantiate(enemySpawn, spawnPoint.transform, true);
                currentSpawnTimer = spawnTimer;
                spawnCount--;
            }
        }
    }
}
