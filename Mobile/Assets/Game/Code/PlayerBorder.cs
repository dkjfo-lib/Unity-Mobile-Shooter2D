using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    public int damage = 1;
    public bool flipX = false;
    public bool flipY = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.transform.parent.GetComponent<PlayerHealth>();
        var steer = collision.transform.parent.GetComponent<PlayerSteer>();
        var projectile = collision.transform.parent.GetComponent<PlayerProjectile>();

        if (player != null)
        {
            // player
            player.GetDamage(damage);
            if (flipX) steer.SetStearing(new Vector2(-steer.movement.Direction.x, steer.movement.Direction.y));
            if (flipY) steer.SetStearing(new Vector2(steer.movement.Direction.x, -steer.movement.Direction.y));
        }
        else if (projectile != null)
        {
            // player projectile
        }
        else
        {
            // unknown object
            Debug.LogError("Wrong collision detected!", collision.transform);
        }
    }
}
