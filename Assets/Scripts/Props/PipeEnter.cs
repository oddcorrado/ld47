using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeEnter : MonoBehaviour
{

   

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var CheckPlayer = collision.gameObject.GetComponent<PlayerMove>();

        if (CheckPlayer != null)
        {
            CheckPlayer.MoveToExit();          
        }

        
    }


}
