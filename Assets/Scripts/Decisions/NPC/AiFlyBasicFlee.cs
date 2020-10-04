using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFlyBasicFlee : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] GameObject target;
    [SerializeField] float seeDistance, idleSpeed, fleeSpeed;

    void FixedUpdate()
    {
        var targetDirection = gameObject.transform.localPosition - target.transform.localPosition;

        if (targetDirection.magnitude < seeDistance)
        {
            controller.PressedState = new Controller.Pressed()
            {
                hor = fleeSpeed * targetDirection.normalized.x,
                ver = fleeSpeed * targetDirection.normalized.y,
            };
        }
        else
        {
            controller.PressedState = new Controller.Pressed()
            {
                hor = idleSpeed * (Random.value - 0.5f),
                ver = idleSpeed * (Random.value - 0.5f),
            };
        }
    }
}
