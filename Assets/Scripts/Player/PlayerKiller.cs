using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var life = collision.gameObject.GetComponent<PlayerLife>();

        Debug.Log("PlayerKiller:  " + collision.gameObject + " " + life);
        if (life != null) life.Die();
    }
}