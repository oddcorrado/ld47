using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private StateManager stateManager;

    void Start()
    {
        if (spawnPoint == null) spawnPoint = transform;
        stateManager = FindObjectOfType<StateManager>();
    }

    public void Die()
    {
        transform.position = spawnPoint.position;
        stateManager.StartWheel();
    }
}