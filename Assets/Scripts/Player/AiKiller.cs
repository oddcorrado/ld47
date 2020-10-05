using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiKiller : MonoBehaviour
{
    [SerializeField] Animator dartAnimator;
    [SerializeField] SoundFxPlayer soundFxPlayer;

    private Coroutine coroutine;


    IEnumerator AnimationTimer()
    {
        dartAnimator.SetInteger("state", 1);
        yield return new WaitForSeconds(1);
        dartAnimator.SetInteger("state", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var brouterLife = collision.gameObject.GetComponent<AiBrouterLife>();

        if (brouterLife != null)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(AnimationTimer());

            soundFxPlayer.PlaySound(SoundFxPlayer.SoundFx.AI_DIE);
            brouterLife.Die();
        }

        var buzzerLife = collision.gameObject.GetComponentInParent<AiBuzzerLife>();

        if (buzzerLife != null)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(AnimationTimer());

            soundFxPlayer.PlaySound(SoundFxPlayer.SoundFx.AI_DIE);
            buzzerLife.Die();
        }
    }
}
