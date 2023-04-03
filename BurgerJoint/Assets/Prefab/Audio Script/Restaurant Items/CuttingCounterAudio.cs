using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CuttingCounterAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private List<AudioClip> cuttingSfxClips;
    [SerializeField] private CuttingCounter cuttingCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        cuttingCounter.OnCut += PlayCutSFX;
    }


    public void PlayCutSFX(object sender, EventArgs eventArgs)
    {
        source.PlayOneShot(cuttingSfxClips[Random.Range(0, cuttingSfxClips.Count)]);
    }
}
