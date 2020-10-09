using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeExit : MonoBehaviour
{
    public GameObject PipeEnter;
    public GameObject player;

    public void MoveToEnter()
    {
        player.transform.position = PipeEnter.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var m = collision.collider.GetComponent<Mutator>();

        if (m.CurrentState == LoopState.Larva) player.transform.position = PipeEnter.transform.position;
    }
}
