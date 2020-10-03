using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutator : MonoBehaviour
{
    [SerializeField] GameObject larva;
    [SerializeField] GameObject cockcroach;
    [SerializeField] GameObject butterfly;

    private StateManager stateManager;
    private LoopState currentState;

    IEnumerator Start()
    {
        yield return null;
        stateManager = FindObjectOfType<StateManager>();
        currentState = stateManager.CurrentState;
        ActivateState(currentState);
    }

    void ActivateState(LoopState state)
    {
        larva.SetActive(false);
        cockcroach.SetActive(false);
        butterfly.SetActive(false);
        switch(state)
        {
            case LoopState.State1: larva.SetActive(true); return;
            case LoopState.Transition12: larva.SetActive(true); return;
            case LoopState.State2: cockcroach.SetActive(true); return;
            case LoopState.Transition23: cockcroach.SetActive(true); return;
            case LoopState.State3: butterfly.SetActive(true); return;
            case LoopState.Transition31: butterfly.SetActive(true); return;
        }
    }

    void Update()
    {
        if (stateManager == null) return;
        if (currentState == stateManager.CurrentState) return;

        currentState = stateManager.CurrentState;
        ActivateState(currentState);
    }
}
