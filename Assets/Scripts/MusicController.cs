﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource[] sources;
    [SerializeField] float maxVolume = 0.5f;

    public int Index { get; set; } = 0;

    private void Update()
    {
        for(int i = 0; i < sources.Length; i++)
        {
            var source = sources[i];
            if(i != Index)
            {
                if (source.volume > 0)
                    source.volume = Mathf.Max(0, source.volume - 0.02f);
            }
            else
            {
                if (source.volume < maxVolume)
                    source.volume = Mathf.Min(maxVolume, source.volume + 0.02f);
            }
        }
    }
}
