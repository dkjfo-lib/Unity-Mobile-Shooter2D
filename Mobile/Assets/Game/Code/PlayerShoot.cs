using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public MoveStraight projectile;

    public float reloadTime = .5f;

    private Transform SceneHolder => GameManager.GetInstance.SceneHolder;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(reloadTime);
            Instantiate(projectile, transform.position, Quaternion.identity, SceneHolder).SetDirection(transform.up);
        }
    }
}
