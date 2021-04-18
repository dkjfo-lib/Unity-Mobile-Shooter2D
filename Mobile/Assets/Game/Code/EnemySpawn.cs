using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Vector2 SPdir;
    [Space]
    public bool spawning = false;

    public bool IsReadyToSpawn => !spawning;
    public Transform sceneHolder => GameManager.GetInstance.SceneHolder;

    public void Spawn(BaseEnemy enemy, Transform player, float delay = 0)
    {
        StartCoroutine(SpawnEnemy(enemy, player, delay));
    }

    private IEnumerator SpawnEnemy(BaseEnemy enemy, Transform player, float delay)
    {
        spawning = true;
        if (delay != 0)
        {
            yield return new WaitForSeconds(delay);
        }
        var n = GameObject.Instantiate(enemy, transform.position, Quaternion.identity, sceneHolder);
        n.Init(SPdir, player);
        spawning = false;
    }
}
