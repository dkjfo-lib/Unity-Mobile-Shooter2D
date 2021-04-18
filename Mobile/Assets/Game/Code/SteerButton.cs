using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SteerButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler
{
    public bool isLeft;

    public PlayerSteer PlayerSteer => GameManager.GetInstance.PlayerSteer;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isLeft)
            PlayerSteer.localLeft = true;
        else
            PlayerSteer.localRight = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isLeft)
            PlayerSteer.localLeft = false;
        else
            PlayerSteer.localRight = false;
    }
}
