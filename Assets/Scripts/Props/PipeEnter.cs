using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeEnter : MonoBehaviour
{
    public GameObject PipeExit;
    public GameObject player;

   public void MoveToExit()
    {
        player.transform.position = PipeExit.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var m = collision.collider.GetComponent<Mutator>();

        if (m!= null && m.CurrentState == LoopState.Larva) player.transform.position = PipeExit.transform.position;
    }
}
