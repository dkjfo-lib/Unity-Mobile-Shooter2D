using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteer : MonoBehaviour
{
    public MoveStraight movement;
    [Space]
    public float rotationSpeed = 1;
    [Space]
    public bool localRight = false;
    public bool TurnRight => Input.GetKey(KeyCode.D) || localRight;
    public bool localLeft = false;
    public bool TurnLeft => Input.GetKey(KeyCode.A) || localLeft;

    private void Awake()
    {
        GameManager.GetInstance.SetPlayer(this);
    }

    private void Update()
    {
        Steer();
    }

    private void Steer()
    {
        float steer = GetSteer();
        if (steer != 0)
        {
            float angles = steer * rotationSpeed;
            transform.Rotate(0, 0, angles);
            movement.SetDirection(transform.up);
        }
    }

    private float GetSteer()
    {
        float steer = 0;
        if (TurnLeft) steer -= 1;
        if (TurnRight) steer += 1;
        return steer;
    }

    public void SetStearing(Vector2 newDirection)
    {
        transform.up = newDirection;
        movement.SetDirection(transform.up);
    }
}
