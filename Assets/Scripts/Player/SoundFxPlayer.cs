using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxPlayer : MonoBehaviour
{
    [SerializeField] AudioSource[] sources;

    public enum SoundFx { AI_DIE, PLAYER_DIE, PLAYER_JUMP, NEST_CATCH, NEST_DROP, NEST_FINISHED }

    public void PlaySound(SoundFx fx)
    {
        if((int)fx < sources.Length)
        {
            sources[(int)fx].Play();
        }
    }
}
