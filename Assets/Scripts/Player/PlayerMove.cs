using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject PipeEnter;
    public GameObject PipeExit;
    

    public void MoveToExit()
    {
        gameObject.transform.position = PipeExit.transform.position;
    }

    public void MoveToEnter()
    {
        gameObject.transform.position = PipeEnter.transform.position;
    }


}
