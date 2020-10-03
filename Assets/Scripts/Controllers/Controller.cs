using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public class Pressed
    {
        public float hor;
        public float ver;
    }

    public Pressed PressedState { get; set; }
}
