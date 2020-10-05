using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        var m = col.gameObject.GetComponent<Mutator>();
        if (m != null) m.isHidden = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        var m = col.gameObject.GetComponent<Mutator>();
        if (m != null) m.isHidden = false;
    }
}