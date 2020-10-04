using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject prefabFx;

    private StateManager stateManager;

    void Start()
    {
        if (spawnPoint == null) spawnPoint = transform;
        stateManager = FindObjectOfType<StateManager>();
    }

    public void Die()
    {
        var fx = Instantiate(prefabFx);
        fx.transform.position = transform.position;

        Debug.Log("KILL ME");
        transform.position = spawnPoint.position;
        stateManager.Reset();
    }
}