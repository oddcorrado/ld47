using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGround : Controller
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float hspeed = 10;
    [SerializeField] float vspeed = 10;
    [SerializeField] float inertia = 0.8f;
    [SerializeField] float gravity = 10;

    protected virtual void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("wall");
        var cast = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, mask);

        Vector2 vel = body.velocity;

        if (Mathf.Abs(PressedState.hor) > 0 ) vel = new Vector2(hspeed * PressedState.hor, vel.y);
        else vel = new Vector2(vel.x * inertia, vel.y);

        if (Mathf.Abs(PressedState.ver) > 0 && cast.collider != null) vel += new Vector2(0, vspeed);
        else vel+= new Vector2(0, -gravity);

        body.velocity = vel;
    }
}
