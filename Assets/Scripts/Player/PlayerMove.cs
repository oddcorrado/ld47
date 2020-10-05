using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject PipeEnter;
    public GameObject PipeExit;

    public bool Larva = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var CheckPipeEnter = collision.gameObject.GetComponent<PipeEnter>();
        var CheckPipeExit = collision.gameObject.GetComponent<PipeExit>();

        if(CheckPipeEnter != null)
        {
            if(Larva == true)
            {
                CheckPipeEnter.MoveToExit();
            }
            
        }

        if(CheckPipeExit != null)
        {
            if(Larva == true)
            {
                CheckPipeExit.MoveToEnter();
            }
        }


    }

}
