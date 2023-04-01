using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDoorBellAudio : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private List<AudioClip> doorbellGreetings;
    [SerializeField] private List<AudioClip> doorbellGoodbyes;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    public void PlayEntryGreeting()
    {
        AudioClip clip = doorbellGreetings[Random.Range(0, doorbellGreetings.Count)];
        
        source.PlayOneShot(clip);
    }
    
    public void PlayExitGreeting()
    {
        AudioClip clip = doorbellGoodbyes[Random.Range(0, doorbellGoodbyes.Count)];
        
        source.PlayOneShot(clip);
    }
}
