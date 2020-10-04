using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource[] sources;
    [SerializeField] float maxVolume = 0.5f;
    [SerializeField] float fadeSpeed = 0.002f;

    public int Index { get; set; } = 0;

    

    private void Update()
    {
        

        for(int i = 0; i < sources.Length; i++)
        {
            var source = sources[i];
            if(i != Index)
            {
                if (source.volume > 0)
                    source.volume = Mathf.Max(0, source.volume - fadeSpeed);
            }
            else
            {
                if (source.volume < maxVolume)
                    source.volume = Mathf.Min(maxVolume, source.volume + fadeSpeed);
            }
        }


        
    }

    void CurrentState(LoopState a)
    {
        switch (a)
        {
            case LoopState.LarvaBirth:
                Index = 1;
                break;
            case LoopState.LarvaToRoach:
                Index = 2;
                break;
            case LoopState.RoachToButterfly:
                Index = 3;
                break;

        }
    }

}
