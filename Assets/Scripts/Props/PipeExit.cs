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


}
