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
    [SerializeField] float maxFallVelocity = -10;

    protected virtual void FixedUpdate()
    {
        if (body == null) return;

        LayerMask mask = LayerMask.GetMask("wall");
        var castLeft = Physics2D.Raycast(transform.position - new Vector3(0.5f, 0, 0), Vector2.down, 1.05f, mask);
        var castCenter = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, mask);
        var castRight = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0, 0), Vector2.down, 1.05f, mask);

        var IsGrounded = castLeft.collider != null || castCenter.collider != null || castRight.collider != null;

        var vel = body.velocity;

        if (Mathf.Abs(PressedState.hor) > 0 ) vel = new Vector2(hspeed * PressedState.hor, vel.y);
        else vel = new Vector2(vel.x * inertia, vel.y);

        if (Mathf.Abs(PressedState.ver) > 0 && IsGrounded) vel += new Vector2(0, vspeed);
        else vel = new Vector2(vel.x, Mathf.Max(vel.y - gravity, maxFallVelocity));

        if (!IsGrounded)
            AnimatorState = 2;
        else
        {
            if (Mathf.Abs(PressedState.hor) > 0) AnimatorState = 1;
            else AnimatorState = 0;
        }

        body.velocity = vel;
    }
}
