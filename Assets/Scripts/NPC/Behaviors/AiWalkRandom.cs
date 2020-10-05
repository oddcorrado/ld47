using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AiWalkRandom : MonoBehaviour
{
    [SerializeField] Controller controller;
    public float startX, endX;

    bool leftDirection = false;
    bool active = true;

    float timeStart, timeSpan, speed;

    private void Start()
    {
        SetRandomState();
    }
    void FixedUpdate()
    {
        if(transform.localPosition.x < startX)
        {
            leftDirection = false;
        }
        if(transform.localPosition.x > endX)
        {
            leftDirection = true;
        }

        if (timeStart + timeSpan < Time.time)
        {
            SetRandomState();
        }
        Debug.Log(controller == null);
        controller.PressedState = new Controller.Pressed() { hor = (speed * (leftDirection ? -1f : 1f)) * (active ? 1f : 0f) };
    }

    void SetRandomState()
    {
        active = Random.value > 0.25f;

        if(Random.value > 0.5f)
        {
            leftDirection = Random.value > 0.5f;
        }

        timeStart = Time.time;
        timeSpan = 1f + Random.value;
        speed = 0.05f + Random.value * 0.1f;
    }
}