using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseSingleton<GameManager>
{
    [System.Obsolete]
    public PlayerSteer player;
    [System.Obsolete]
    public Transform sceneHolder;
    [Space]
    [System.Obsolete]
    public float score;

    public PlayerSteer PlayerSteer => player;
    public Transform PlayerTransform => PlayerSteer.transform;
    public Transform SceneHolder => sceneHolder;
    public float Score => score;

    private void Update()
    {
        AddScore(Time.deltaTime, false);
    }

    public void AddScore(float value, bool playEffects)
    {
        if (playEffects)
        {
            // play effects
        }
        score += value;
    }

    public void SetPlayer(PlayerSteer newPlayer)
    {
        player = newPlayer;
    }
}
