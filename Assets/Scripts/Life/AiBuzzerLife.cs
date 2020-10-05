using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBuzzerLife : MonoBehaviour
{
    [SerializeField] GameObject prefabCorpse;
    [SerializeField] GameObject prefabFx;

    [SerializeField] AiBuzzer me;

    public bool isAttacking;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var life = collision.gameObject.GetComponent<PlayerLife>();
        if (life != null) Debug.LogWarning("found life");
        if (life != null && isAttacking)
        {
            life.Die();
        }
    }

    public void Die()
    {
        var go = Instantiate(prefabCorpse);
        go.transform.localPosition = me.body.localPosition;

        var fx = Instantiate(prefabFx);
        fx.transform.position = transform.position;
        fx.transform.parent = go.transform;

        Destroy(me.gameObject);
    }
}
