using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageReciever
{
    public int health = 3;
    public float invoronabilityDuration = 1;
    [Space]
    public bool canTakeDamage = true;

    public bool CanTakeDamage => canTakeDamage;

    public void GetDamage(int damage)
    {
        if (!CanTakeDamage)
        {
            return;
        }

        if (damage < health)
        {
            // play effects
            StartCoroutine(GetInvoronability(invoronabilityDuration));
            health -= damage;
        }
        else
        {
            Die();
        }
    }

    IEnumerator GetInvoronability(float duration)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(duration);
        canTakeDamage = true;
    }

    public void GetHeal(int heal)
    {
        // play effects
        health += heal;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // play effects
        // call respawn or restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

public interface IDamageDealer
{
    int Damage { get; }
}

public interface IDamageReciever
{
    void GetDamage(int damage);
}