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


}
