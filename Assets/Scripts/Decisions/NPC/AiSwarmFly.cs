using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSwarmFly : MonoBehaviour
{
    [SerializeField] Controller controller;

    public Vector2 bestDirection = Vector2.zero;
    public Vector2 currentCenterThresholdMod = Vector2.zero;

    public bool isGoingForward = false;

    void FixedUpdate()
    {
        controller.PressedState = new Controller.Pressed()
        {
            hor = bestDirection.x - transform.localPosition.x,
            ver = bestDirection.y - transform.localPosition.y,
        };
    }
}
