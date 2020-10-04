using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBuzzerLife : MonoBehaviour
{
    [SerializeField] GameObject prefabCorpse;

    Mutator m;
    LoopState lastKnownState = LoopState.LarvaBirth;

    private void Start()
    {
        ResetTarget();
    }

    private void LateUpdate()
    {
        if(m == null)
        {
            ResetTarget();
        }
        else if(lastKnownState != m.GetCurrentState())
        {
            ResetState();
        }
    }

    void ResetState()
    {
        lastKnownState = m.GetCurrentState();

        if (lastKnownState == LoopState.LarvaToRoach || lastKnownState == LoopState.Roach)
        {
            GetComponent<AiFlyBasicFlee>().enabled = true;
            GetComponent<AiFlyBasicAttack>().enabled = false;
        }
        else
        {
            GetComponent<AiFlyBasicFlee>().enabled = false;
            GetComponent<AiFlyBasicAttack>().enabled = true;
        }
    }

    void ResetTarget()
    {
        m = FindObjectOfType<Mutator>();
        if (m != null)
        {
            GetComponent<AiFlyBasicAttack>().target = m.gameObject;
            GetComponent<AiFlyBasicFlee>().target = m.gameObject;
        }
    }

    public void Die()
    {
        var go = Instantiate(prefabCorpse);
        go.transform.position = transform.position;

        Destroy(gameObject);
    }
}
