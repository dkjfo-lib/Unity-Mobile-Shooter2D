using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public void Init(Vector2 SPdir, Transform player);
}

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public virtual void Init(Vector2 SPdir, Transform player)
    {
        throw new System.NotImplementedException();
    }
}

public class EnemyStraight : BaseEnemy
{
    public MoveStraight movement;
    public Transform player;

    public override void Init(Vector2 SPdir, Transform player)
    {
        this.player = player;
        this.movement.SetDirection(SPdir);
    }
}