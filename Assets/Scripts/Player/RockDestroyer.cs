﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        var life =
        collision.gameObject.GetComponent<RockLife>();

        if (life != null) life.Die();

    }
}
