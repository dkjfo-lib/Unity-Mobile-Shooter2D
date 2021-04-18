using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour, IDamageDealer, IDamageReciever
{
    public int health = 1;
    public int damage = 1;

    public int Damage => damage;

    public void GetDamage(int damage)
    {
        if (damage < health)
        {
            // play effects
            health -= damage;
        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // play effects
    }
}
