using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip introGreeting; 
    [SerializeField] private AudioClip goodReview;
    [SerializeField] private AudioClip badReview;


    public void PlayIntroGreeting()
    {
        source.clip = introGreeting;
        source.Play();
    }
    
    public void PlayGoodReview()
    {
        source.clip = goodReview;
        source.Play();
    }
    
    
    public void PlayBadReview()
    {
        source.clip = badReview;
        source.Play();
    }

}
