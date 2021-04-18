using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    public Vector3 Direction => new Vector3(direction.x, direction.y);

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += Direction * speed * Time.deltaTime;
    }
}
