using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiKiller : MonoBehaviour
{
    [SerializeField] Animator dartAnimator;

    private Coroutine coroutine;


    IEnumerator AnimationTimer()
    {
        dartAnimator.SetInteger("state", 1);
        yield return new WaitForSeconds(1);
        dartAnimator.SetInteger("state", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var life = collision.gameObject.GetComponent<AILife>();

        if (life != null)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(AnimationTimer());

            life.Die();
        }
    }
}
