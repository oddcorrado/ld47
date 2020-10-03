using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRandomFly : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] float startX, startY, endX, endY;

    bool leftDirection = false;
    bool downDirection = false;
    bool active = true;

    float timeStart, timeSpan, verSpeed, horSpeed;

    private void Start()
    {
        SetRandomState();
    }
    void FixedUpdate()
    {
        if (transform.localPosition.x < startX)
        {
            leftDirection = false;
        }
        if (transform.localPosition.x > endX)
        {
            leftDirection = true;
        }
        if (transform.localPosition.y < startY)
        {
            downDirection = false;
        }
        if (transform.localPosition.y > endY)
        {
            downDirection = true;
        }

        if (timeStart + timeSpan < Time.time)
        {
            SetRandomState();
        }
        controller.PressedState = new Controller.Pressed() 
        { 
            hor = horSpeed * (leftDirection ? -1f : 1f) * (active ? 1f : 0f),
            ver = verSpeed * (downDirection ? -1f : 1f) * (active ? 1f : 0f)
        };
    }

    void SetRandomState()
    {
        active = Random.value > 0.25f;

        if (Random.value > 0.5f)
        {
            leftDirection = Random.value > 0.5f;
        }
        if (Random.value > 0.5f)
        {
            downDirection = Random.value > 0.5f;
        }

        timeStart = Time.time;
        timeSpan = 0.2f + Random.value;
        verSpeed = 0.06f + Random.value * 0.12f;
        horSpeed = 0.06f + Random.value * 0.12f;
    }
}
