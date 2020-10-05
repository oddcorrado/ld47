using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBuzzerLife : MonoBehaviour
{
    [SerializeField] GameObject prefabCorpse;

    public void Die()
    {
        var go = Instantiate(prefabCorpse);
        go.transform.position = transform.position;

        Destroy(gameObject);
    }
}
