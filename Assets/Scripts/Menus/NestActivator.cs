using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestActivator : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    [SerializeField] private GameObject[] toShow;
    [SerializeField] private GameObject[] toHide;
    [SerializeField] private string goName;
    [SerializeField] bool once = false;

    private bool done = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (once && done) return;
        if (collision.gameObject.name == goName)
            foreach (var go in toShow)
                go.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        done = true;
        if (collision.gameObject.name == goName)
            foreach (var go in toShow)
                go.SetActive(true);
    }
}