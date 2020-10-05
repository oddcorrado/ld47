using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSwarmerLife : MonoBehaviour
{
    [SerializeField] GameObject prefabCorpse;
    [SerializeField] GameObject prefabFx;

    [SerializeField] AiSwarmer me;

    public bool isAttacking;

    void OnTriggerEnter2D(Collider2D col)
    {
        var life = col.gameObject.GetComponent<PlayerLife>();
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
