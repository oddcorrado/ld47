using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Animator animator;

    public class Pressed
    {
        public float hor;
        public float ver;
    }

    public Pressed PressedState { get; set; }

    private int animatorState = -1;
    public int AnimatorState
    {
        get
        {
            return animatorState;
        }
        set
        {
            Debug.Log("ANIMATOR " + value);
            if (animatorState == value) return;
            animatorState = value;
            if(animator != null) animator.SetInteger("state", value);
        }
    }
}
