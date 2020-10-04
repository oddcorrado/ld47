using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    private StateManager stateManager;
    [SerializeField] private LoopState forcedState;

    IEnumerator Start()
    {
        yield return null;
        stateManager = FindObjectOfType<StateManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            var life = collision.gameObject.GetComponent<PlayerLife>();

            Debug.Log("PlayerKiller:  " + collision.gameObject + " " + life);
            stateManager.ForceState(forcedState);
            Destroy(gameObject);
        }
    }
}
