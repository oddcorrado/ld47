using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxDestroyTimer : MonoBehaviour
{
    [SerializeField] float duration = 1;

    IEnumerator  Start()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
