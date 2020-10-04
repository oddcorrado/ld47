using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBrouterLife : MonoBehaviour
{
    [SerializeField] GameObject prefabCorpse;
    [SerializeField] GameObject prefabFx;

    public void Die()
    {
        var go = Instantiate(prefabCorpse);
        go.transform.position = transform.position;

        var fx = Instantiate(prefabFx);
        fx.transform.position = transform.position;
        fx.transform.parent = go.transform;

        Destroy(gameObject);
    }
}
