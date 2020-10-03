using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFlappy : Controller
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float hspeed = 10;
    [SerializeField] float vspeed = 10;
    [SerializeField] float inertia = 0.8f;
    [SerializeField] float gravity = 10;

    protected virtual void FixedUpdate()
    {
        Vector2 vel = body.velocity;

        if (Mathf.Abs(PressedState.hor) > 0)
        {
            vel = new Vector2(hspeed * PressedState.hor, vel.y);
        }
        else
        {
            vel = new Vector2(vel.x * inertia, vel.y);
        }

        if (Mathf.Abs(PressedState.ver) > 0)
        {
            vel = new Vector2(vel.x, vspeed);
        }
        else
        {
            vel = new Vector2(vel.x, -gravity);
        }

        body.velocity = vel;
    }
}