using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            var m = collision.gameObject.GetComponent<Mutator>();
            if (m != null) m.isHidden = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        {
            var m = collision.gameObject.GetComponent<Mutator>();
            if (m != null) m.isHidden = false;
        }
    }
}