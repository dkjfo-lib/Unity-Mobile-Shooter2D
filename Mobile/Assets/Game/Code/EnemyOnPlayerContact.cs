using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnPlayerContact : MonoBehaviour
{
    public int health = 1;
    public int contactDamage = 1;
    public int score = 10;
    public bool dieOnPlayerContact = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.transform.parent.GetComponent<PlayerHealth>();
        var projectile = collision.transform.parent.GetComponent<PlayerProjectile>();
        var worldBorder = collision.transform.GetComponent<WorldBorder>();
        if (player != null)
        {
            // player
            player.GetDamage(contactDamage);
            if (dieOnPlayerContact)
            {
                GetDamage(100000, false);
            }
        }
        else if (projectile != null)
        {
            // player projectile
            GetDamage(projectile.Damage, true);
            projectile.GetDamage(contactDamage);
        }
        else if (worldBorder != null) { }
        else
        {
            // unknown object
            Debug.LogError("Wrong collision detected!", collision.transform);
        }
    }

    public void GetDamage(int damage, bool addScoreOnDeath)
    {
        if (damage < health)
        {
            // play effect
            health -= damage;
        }
        else
        {
            Die(addScoreOnDeath);
        }
    }

    void Die(bool addScore)
    {
        if (addScore)
        {
            GameManager.GetInstance.AddScore(score, true);
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // play effects
    }
}
