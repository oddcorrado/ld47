using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public GameObject Player;

    public GameObject RespawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = RespawnPoint.transform.position;
    }

}
