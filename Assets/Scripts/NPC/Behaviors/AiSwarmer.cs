using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSwarmer : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] AiBuzzerLife life;
    public Transform body;

    public Mutator target;

    public float speed;

    public Vector3 assignedSwarmPosition;
    public bool isAttacking;

    LoopState lastKnownTargetState = LoopState.LarvaBirth;

    void FixedUpdate()
    {
        if (body != null)
        {
            if (target == null)
            {
                target = FindObjectOfType<Mutator>();
            }
            else if (lastKnownTargetState != target.GetCurrentState())
            {
                lastKnownTargetState = target.GetCurrentState();
            }

            if (target != null)
            {
                var targetDirection = target.transform.localPosition - body.localPosition;

                if (isAttacking)
                {
                    life.isAttacking = true;
                    controller.PressedState = new Controller.Pressed()
                    {
                        hor = speed * targetDirection.normalized.x,
                        ver = speed * targetDirection.normalized.y,
                    };
                }
                else
                {
                    life.isAttacking = false;
                    GoToAssignedSwarmPosition();
                }
            }
            else
            {
                life.isAttacking = false;
                GoToAssignedSwarmPosition();
            }
        }
    }

    void GoToAssignedSwarmPosition()
    {
        var direction = (assignedSwarmPosition - body.localPosition).normalized;
        controller.PressedState = new Controller.Pressed()
        {
            hor = speed * direction.x,
            ver = speed * direction.y
        };
    }
}
