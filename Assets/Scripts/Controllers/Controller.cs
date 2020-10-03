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

    public Pressed PressedState { get; set; } = new Pressed();

    private int animatorState = -1;
    public int AnimatorState
    {
        get
        {
            return animatorState;
        }
        set
        {
            if (animatorState == value) return;
            animatorState = value;
            if(animator != null) animator.SetInteger("state", value);
        }
    }

    protected virtual void Update()
    {
        if (Mathf.Abs(PressedState.hor) < Mathf.Epsilon) return;

        if (PressedState.hor > 0) transform.localScale = new Vector2(-1, 1);
        else transform.localScale = new Vector2(1, 1);
    }

    private void OnEnable()
    {
        AnimatorState = -1;
        AnimatorState = 0;
    }
}
