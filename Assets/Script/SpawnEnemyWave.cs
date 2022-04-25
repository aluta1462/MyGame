using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyWave : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WATING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }


    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    private float waveCountDown;

    private float searchCountDown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("no sp ref");
        }

        waveCountDown = timeBetweenWaves;


    }

    void Update()
    {
        if (state == SpawnState.WATING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
               
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;
        if(nextWave + 1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("All waves Completed");
        }
        else
        {
            nextWave++;
        }
        
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;

            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);

        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }


        state = SpawnState.WATING;

        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        Debug.Log("Spawn enemy: " + enemy.name);
        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, _sp.position, _sp.rotation);

        
    }
}
