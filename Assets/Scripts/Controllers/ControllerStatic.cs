using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerStatic : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float inertia = 0.8f;
    [SerializeField] float gravity = 10;

    protected virtual void FixedUpdate()
    {
        Vector2 vel = body.velocity;

        vel = new Vector2(vel.x * inertia, vel.y);

        vel += new Vector2(0, -gravity);

        body.velocity = Vector2.zero;
    }
}
