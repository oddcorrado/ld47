using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutator : MonoBehaviour
{
    [SerializeField] GameObject larvabirth;
    [SerializeField] GameObject larva;
    [SerializeField] GameObject cockcroach;
    [SerializeField] GameObject butterfly;
    [SerializeField] GameObject larvaToRoach;
    [SerializeField] GameObject roachToButterfly;
    [SerializeField] GameObject butterflyDeath;
    [SerializeField] GameObject nest;

    private StateManager stateManager;
    private LoopState currentState;

    public bool isHidden = false;

    internal LoopState GetCurrentState()
    {
        return currentState;
    }

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
        larvaToRoach.SetActive(false);
        roachToButterfly.SetActive(false);
        butterflyDeath.SetActive(false);
        switch (state)
        {
            case LoopState.LarvaBirth: if (nest != null) { transform.position = nest.transform.position; } larvabirth.SetActive(true); return;
            case LoopState.Larva: larva.SetActive(true); return;
            case LoopState.LarvaToRoach: larvaToRoach.SetActive(true); return;
            case LoopState.Roach: cockcroach.SetActive(true); return;
            case LoopState.RoachToButterfly: roachToButterfly.SetActive(true); return;
            case LoopState.Butterfly: butterfly.SetActive(true); return;
            case LoopState.ButterflyDeath: butterflyDeath.SetActive(true); return;
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
