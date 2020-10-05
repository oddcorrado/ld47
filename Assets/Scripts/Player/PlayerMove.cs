using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject PipeEnter;
    public GameObject PipeExit;

    public bool Larva = false;

    public void MoveToExit()
    {
        if(Larva == true)
        {
            gameObject.transform.position = PipeExit.transform.position;
        }
       
    }

    public void MoveToEnter()
    {
        if(Larva == true)
        {
            gameObject.transform.position = PipeEnter.transform.position;
        }
        
    }


}
