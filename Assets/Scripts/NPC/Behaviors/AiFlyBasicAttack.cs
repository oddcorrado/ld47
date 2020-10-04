using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFlyBasicAttack : MonoBehaviour
{
    [SerializeField] Controller controller;
    public GameObject target;
    [SerializeField] float seeDistance, idleSpeed, attackSpeed;

    void FixedUpdate()
    {
        if (target != null)
        {

            var targetDirection = target.transform.localPosition - gameObject.transform.localPosition;

            if (targetDirection.magnitude < seeDistance)
            {
                controller.PressedState = new Controller.Pressed()
                {
                    hor = attackSpeed * targetDirection.normalized.x,
                    ver = attackSpeed * targetDirection.normalized.y,
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
