using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFloaty : Controller
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float hspeed = 10;
    [SerializeField] float vspeed = 10;
    [SerializeField] float inertia = 0.8f;

    protected virtual void FixedUpdate()
    {
        var vel = body.velocity;

        float horMove, verMove;

        if (PressedState != null && Mathf.Abs(PressedState.hor) > 0)
        {
            horMove = hspeed * PressedState.hor;
        }
        else
        {
            horMove = body.velocity.x * inertia;
        }

        if (PressedState != null && Mathf.Abs(PressedState.ver) > 0)
        {
            verMove = vspeed * PressedState.ver;
        }
        else
        {
            verMove = body.velocity.y * inertia;
        }

        body.velocity = new Vector2(horMove, verMove);
    }
}
