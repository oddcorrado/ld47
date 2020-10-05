using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DecisionPlayer : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] SoundFxPlayer soundFxPlayer;

    private bool prevJump;

    void FixedUpdate()
    {
        if(soundFxPlayer != null && prevJump == false && Keyboard.current.spaceKey.IsPressed())
        {
            prevJump = true;
            soundFxPlayer.PlaySound(SoundFxPlayer.SoundFx.PLAYER_JUMP);
        }

        prevJump = false;
        controller.PressedState = new Controller.Pressed()
        {
            hor = Keyboard.current.leftArrowKey.IsPressed() ? -1 : (Keyboard.current.rightArrowKey.IsPressed() ? 1 : 0),
            ver = Keyboard.current.spaceKey.IsPressed() ? 1: 0
        };
    }
}
