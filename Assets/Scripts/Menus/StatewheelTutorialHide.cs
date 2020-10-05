using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatewheelTutorialHide : MonoBehaviour
{
    void Update()
    {
        if(Keyboard.current.enterKey.IsPressed())
        {
            gameObject.SetActive(false);
        }
    }
}
