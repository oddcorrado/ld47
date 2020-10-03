using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DecisionPlayer : MonoBehaviour
{
    [SerializeField] Controller controller;

    void FixedUpdate()
    {
        controller.PressedState = new Controller.Pressed()
        {
            hor = Keyboard.current.leftArrowKey.IsPressed() ? -1 : (Keyboard.current.rightArrowKey.IsPressed() ? 1 : 0),
            ver = Keyboard.current.spaceKey.IsPressed() ? 1: 0
        };
    }
}
