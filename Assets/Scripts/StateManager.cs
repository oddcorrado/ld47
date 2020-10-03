using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public float[] times = new float[] { 2.5f, 2.1f, 1.7f, 1.4f, 1f, 0.6f };
    float[] rotationAngles = new float[] { 0, 0, 120, 120, 240, 240 };

    public GameObject[] stateImages;

    bool Running = false;

    State CurrentState = State.State1;
    float StartTime;

    int totalStateLength = Enum.GetNames(typeof(State)).Length;

    private void Start()
    {
        StartWheel();
    }

    public void StartWheel()
    {
        if(!Running)
        {
            Running = true;
            CurrentState = (State)0;
            StartTime = Time.time;

            ActivateState(CurrentState);
        }
    }

    private void LateUpdate()
    {
        if(Running)
        {
            int currentIndex = (int)CurrentState;
            int nextIndex = currentIndex + 1;
            if (nextIndex >= totalStateLength) nextIndex = 0;

            float currentRotation = rotationAngles[currentIndex];
            float nextRotation = rotationAngles[nextIndex];
            if (nextIndex == 0) nextRotation = 360f;

            float progress = (Time.time - StartTime) / times[currentIndex];

            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation + progress * (nextRotation - currentRotation)));
            foreach(var g in stateImages)
            {
                g.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -transform.localRotation.eulerAngles.z));
            }

            if(progress > 1)
            {
                CurrentState = (State)nextIndex;
                StartTime = Time.time;

                ActivateState(CurrentState);
            }
        }
    }

    void ActivateState(State s)
    {
        switch (s)
        {
            case State.State1:
                Debug.Log("Activating " + State.State1.ToString() + " for " + times[(int)State.State1] + " seconds");
                break;
            case State.Transition12:
                Debug.Log("Activating " + State.Transition12.ToString() + " for " + times[(int)State.Transition12] + " seconds");
                break;
            case State.State2:
                Debug.Log("Activating " + State.State2.ToString() + " for " + times[(int)State.State2] + " seconds");
                break;
            case State.Transition23:
                Debug.Log("Activating " + State.Transition23.ToString() + " for " + times[(int)State.Transition23] + " seconds");
                break;
            case State.State3:
                Debug.Log("Activating " + State.State3.ToString() + " for " + times[(int)State.State3] + " seconds");
                break;
            case State.Transition31:
                Debug.Log("Activating " + State.Transition31.ToString() + " for " + times[(int)State.Transition31] + " seconds");
                break;
        }
    }
}


enum State
{
    State1,
    Transition12,
    State2,
    Transition23,
    State3,
    Transition31
}


