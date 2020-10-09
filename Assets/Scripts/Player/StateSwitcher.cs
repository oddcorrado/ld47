using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    private StateManager stateManager;
    [SerializeField] private LoopState forcedState;
    [SerializeField] private LoopState requiredState = LoopState.RoachToButterfly;
    [SerializeField] private bool killOnSwitch;
    [SerializeField] private bool anyState = true;

    private float lastDate = 0;

    IEnumerator Start()
    {
        yield return null;
        stateManager = FindObjectOfType<StateManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            var m = collision.gameObject.GetComponent<Mutator>();

            if (m != null && (anyState || requiredState == m.CurrentState) && Time.time > lastDate + 3)
            {
                stateManager.ForceState(forcedState);


                lastDate = Time.time;
                if (killOnSwitch) Destroy(gameObject);
            }
        }
    }
}
