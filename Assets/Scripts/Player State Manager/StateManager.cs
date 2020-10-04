using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public float[] timesInSeconds;

    float[] rotationAngles = new float[] { 0, 0, 120, 120, 240, 240, 360 };

    public GameObject[] stateImages;

    bool Running = false;

    public LoopState CurrentState = LoopState.LarvaBirth;
    float StartTime;

    int totalStateLength = Enum.GetNames(typeof(LoopState)).Length;

    private MusicController musicController;

    private void Start()
    {
        StartWheel();
        musicController = FindObjectOfType<MusicController>();
    }

    public void StartWheel()
    {
        if (!Running)
        {
            Running = true;
            CurrentState = (LoopState)0;
            StartTime = Time.time;

            ActivateState(CurrentState);
        }
    }

    public void Reset()
    {
        CurrentState = (LoopState)0;
        StartTime = Time.time;

        ActivateState(CurrentState);
    }

    private void LateUpdate()
    {
        if (Running)
        {
            int currentIndex = (int)CurrentState;
            int nextIndex = currentIndex + 1;
            if (nextIndex >= totalStateLength) nextIndex = 0;

            float currentRotation = rotationAngles[currentIndex];
            float nextRotation = rotationAngles[nextIndex];
            if (nextIndex == 0) nextRotation = 360f;

            float progress = (Time.time - StartTime) / timesInSeconds[currentIndex];

            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation + progress * (nextRotation - currentRotation)));
            foreach (var g in stateImages)
            {
                g.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -transform.localRotation.eulerAngles.z));
            }

            if (progress > 1)
            {
                CurrentState = (LoopState)nextIndex;
                StartTime = Time.time;

                ActivateState(CurrentState);
            }
        }
    }

    void ActivateState(LoopState s)
    {
        //if (musicController == null) musicController = FindObjectOfType<MusicController>();
        switch (s)
        {
            case LoopState.LarvaBirth:
                Debug.Log("Activating " + LoopState.LarvaBirth.ToString() + " for " + timesInSeconds[(int)LoopState.LarvaBirth] + " seconds");
                break;
            case LoopState.Larva:
                Debug.Log("Activating " + LoopState.Larva.ToString() + " for " + timesInSeconds[(int)LoopState.Larva] + " seconds");
                if (musicController != null) musicController.Index = 0;
                break;
            case LoopState.LarvaToRoach:
                Debug.Log("Activating " + LoopState.LarvaToRoach.ToString() + " for " + timesInSeconds[(int)LoopState.LarvaToRoach] + " seconds");
                break;
            case LoopState.Roach:
                Debug.Log("Activating " + LoopState.Roach.ToString() + " for " + timesInSeconds[(int)LoopState.Roach] + " seconds");
                if (musicController != null) musicController.Index = 1;
                break;
            case LoopState.RoachToButterfly:
                Debug.Log("Activating " + LoopState.RoachToButterfly.ToString() + " for " + timesInSeconds[(int)LoopState.RoachToButterfly] + " seconds");
                break;
            case LoopState.Butterfly:
                Debug.Log("Activating " + LoopState.Butterfly.ToString() + " for " + timesInSeconds[(int)LoopState.Butterfly] + " seconds");
                if (musicController != null) musicController.Index = 2;
                break;
            case LoopState.ButterflyDeath:
                Debug.Log("Activating " + LoopState.ButterflyDeath.ToString() + " for " + timesInSeconds[(int)LoopState.Butterfly] + " seconds");
                break;
        }
    }
}


public enum LoopState
{
    LarvaBirth,
    Larva,
    LarvaToRoach,
    Roach,
    RoachToButterfly,
    Butterfly,
    ButterflyDeath
}


