using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] toShow;
    [SerializeField] private GameObject[] toHide;
    [SerializeField] private string activatorName = "Player";
    [SerializeField] bool once = false;
    [SerializeField] bool activate = true;

    private bool done = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log($"ACTIVATOR {name} hits {collision.gameObject.name}");
        if (once && done) return;
        if(collision.gameObject.name == activatorName)
            foreach (var go in toShow)
                go.SetActive(activate);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        done = true;
        if (collision.gameObject.name == activatorName)
            foreach (var go in toHide)
                go.SetActive(!activate);
    }
}
