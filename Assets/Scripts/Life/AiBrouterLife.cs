using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBrouterLife : MonoBehaviour
{
    [SerializeField] GameObject prefabCorpse;
    public void Die()
    {
        var go = Instantiate(prefabCorpse);
        Destroy(gameObject);
        go.transform.position = transform.position;

    }
}
