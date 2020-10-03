using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var life = collision.gameObject.GetComponent<AILife>();

        Debug.Log("AiKiller:  " + collision.gameObject + " " + life);
        if (life != null) life.Die();
    }
}
