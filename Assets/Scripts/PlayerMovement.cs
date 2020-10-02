using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float hspeed = 10;
    [SerializeField] float vspeed = 10;
    [SerializeField] float inertia = 0.8f;
    [SerializeField] float gravity = 10;

    void FixedUpdate()
    {
        var pressed = CheckInput();
        LayerMask mask = LayerMask.GetMask("wall");
        var cast = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, mask);

        if (pressed.left) body.velocity = new Vector2(-hspeed, body.velocity.y);
        if (pressed.right) body.velocity = new Vector2(hspeed, body.velocity.y);
        if (!pressed.left && !pressed.right) body.velocity = new Vector2(body.velocity.x * inertia, body.velocity.y);
        if (pressed.jump && cast.collider != null) body.velocity += new Vector2(0, vspeed);
        else body.velocity += new Vector2(0, -gravity);
    }    

    class Pressed
    {
        public bool left;
        public bool right;
        public bool jump;
    }

    Pressed CheckInput()
    {
        return new Pressed()
        {
            left = Keyboard.current.leftArrowKey.IsPressed(),
            right = Keyboard.current.rightArrowKey.IsPressed(),
            jump = Keyboard.current.spaceKey.IsPressed()
        };
    }
}
