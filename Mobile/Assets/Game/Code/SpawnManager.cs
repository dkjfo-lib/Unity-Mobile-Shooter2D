using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : BaseSingleton<SpawnManager>
{
    public EnemyOnPlayerContact enemyType;
    public EnemySpawn[] spawns;

    public Transform Player => GameManager.GetInstance.PlayerTransform;

    private void Start()
    {
        spawns = GetComponentsInChildren<EnemySpawn>();
        StartCoroutine(ManageSpawn());
    }

    IEnumerator ManageSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        List<EnemySpawn> readySpawns = spawns.Where(s => s.IsReadyToSpawn).ToList();
        List<EnemySpawn> waveSpawns = new List<EnemySpawn>();

        float scoreSqrt = Mathf.Sqrt(GameManager.GetInstance.Score);
        float rawWaveDifficulty = scoreSqrt / enemyType.score;
        int waveDifficulty = (int)Mathf.Ceil(rawWaveDifficulty);

        // choose spawns 
        for (int i = 0; i < waveDifficulty; i++)
        {
            int spawnId = Random.Range(0, readySpawns.Count);
            var spawn = readySpawns[spawnId];
            waveSpawns.Add(spawn);
            readySpawns.Remove(spawn);
        }

        // call spawn enemy
        foreach (var spawn in waveSpawns)
        {
            float delay = Random.Range(.0f, 2.5f);
            spawn.Spawn(enemyType.GetComponent<BaseEnemy>(), Player, delay);
        }
    }
}
