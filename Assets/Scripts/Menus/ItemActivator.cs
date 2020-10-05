using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    [SerializeField] private GameObject[] toShow;
    [SerializeField] private GameObject[] toHide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var life = collision.gameObject.GetComponent<PlayerLife>();
        if(life != null)
            foreach (var go in toShow)
                go.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var life = collision.gameObject.GetComponent<PlayerLife>();
        if (life != null)
            foreach (var go in toHide)
                go.SetActive(false);
    }
}
