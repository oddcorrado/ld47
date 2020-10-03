using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorpseCatcher : MonoBehaviour
{
    [SerializeField] private int corpseCount;

    private void OnEnable()
    {
        corpseCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var life = collision.gameObject.GetComponent<CorpseLife>();

        if (life != null)
        {
            life.Die();
            corpseCount++;
        }
    }
}
