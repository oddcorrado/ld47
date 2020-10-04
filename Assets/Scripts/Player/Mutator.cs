using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutator : MonoBehaviour
{
    [SerializeField] GameObject larva;
    [SerializeField] GameObject cockcroach;
    [SerializeField] GameObject butterfly;
    [SerializeField] GameObject larvaTransition;
    [SerializeField] GameObject cockcroachTransition;
    [SerializeField] GameObject butterflyTransition;
    [SerializeField] GameObject nest;

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
        larvaTransition.SetActive(false);
        cockcroachTransition.SetActive(false);
        butterflyTransition.SetActive(false);
        switch (state)
        {
            case LoopState.State1: if (nest != null) { transform.position = nest.transform.position; } larva.SetActive(true); return;
            case LoopState.Transition12: larvaTransition.SetActive(true); return;
            case LoopState.State2: cockcroach.SetActive(true); return;
            case LoopState.Transition23: cockcroachTransition.SetActive(true); return;
            case LoopState.State3: butterfly.SetActive(true); return;
            case LoopState.Transition31: butterflyTransition.SetActive(true); return;
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
