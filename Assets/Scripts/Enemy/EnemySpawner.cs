using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; //a list of groups of enemies to spawn in this wave
        public int waveQuota;       //total number of enemies spawns in this wave
        public float spawnInterval;  //The interval at which to spawn enemies
        public int spawnCount;      //the number of enemies already spawn in this wave
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string Enemyname;
        public int enemyCount;          //The number of enemies to spawn in this wave
        public int spawnCount;          //the number of enemies already spawn in this wave
        public GameObject enemyPrefab;
    }

    public List<Wave> waves; //list of all the waves in the game
    public int currentWaveCount;

    [Header("Spawner Attributes")]
    float spawnTimer; //timer to determine when to spawn next enemy
    public int EnemiesAlive;
    public int maxEnemiesAllowed;           // max number of enemies allowed on the map at once
    public bool maxEnemiesReached = false;  // a flag indicating if the number of enemies reach maximum
    public float waveInterval; // interval between each wave

    [Header("Spawn Position")]
    public List<Transform> relativeSpawnPoints; //a list to store all relative spawn point of enemies

    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount==0) //check if the wave has ended and the next wave should start
        {
            StartCoroutine(BeginNextWave());
        }
        spawnTimer += Time.deltaTime;

        //check if its time to spawn next enemy
        if(spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        //wave for waveInterval seconds before starting the next wave
        yield return new WaitForSeconds(waveInterval);

        //if there are more waves to start after the current wave, move on to next wave
        if(currentWaveCount < waves.Count-1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        //Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies()
    {
        //Check of the minium number of enemies in the wave  have been spawned
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            //spawn each type of enemy until the quota is filled
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                //check if the minium number of enemies of this type have been spawned
                if(enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    //limit the number of enemies that can be spawned at once
                    if(EnemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    ///spawn enemy at random position close to the player
                    Instantiate(enemyGroup.enemyPrefab, player.position
                                + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    EnemiesAlive++;
                }
            }
        }
        //reset the maxEnemiesReached flag of the number of enemies alive has dropped below the maximum amount
        if(EnemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }

    public void OnEnemyKilled()
    {
        EnemiesAlive--;
    }
}
