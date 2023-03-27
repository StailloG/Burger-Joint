using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSystemBase : MonoBehaviour
{
    [Header("Music System Base setup")]
    [Tooltip("the music clips you will place in, each clip is one layer")]
    [SerializeField] private AudioClip[] audioStems;
  
    [Tooltip("The time it takes to fade in for start and increasing intensity")]
    [SerializeField][Range(0.01f, 12f)] private float fadeInTime = 1.5f;
  
    [Tooltip("The time it takes to fade out for stop and decreasing intensity")]
    [SerializeField][Range(0.01f, 12f)] private float fadeOutTime = 1.5f;
  
    [Tooltip("If you are using the Unity Audio Mixer, this is where they will be routed to, else leave empty")]
    [SerializeField] private AudioMixerGroup musicMixerGroup; 
  
    //the AudioSources that will be playing the clips
    private AudioSource[] audioSources;
    
    
     protected const float MusicVolumeMax = 1.0f;
    
    //currently used as a way to stop multiple starts
    private bool musicSystemIsOn = false;
    
    //helper variable to initialize the AudioSources 
    private int amountOfStems;
    
    private void Awake()
    {
        Init();
    }

    protected void Init()
    {
        amountOfStems = audioStems.Length;

        if (amountOfStems <= 0)
        {
            Debug.LogWarning("No audio clips added to the audio stems!!");
            return; 
        }
        audioSources = new AudioSource[amountOfStems];
    
        for (int i = 0; i < amountOfStems; i++)
        {
            //spawn all the AudioSources
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
    
            //configure the audioSource properties 
            newAudioSource.playOnAwake = false;
            newAudioSource.loop = true;

            //assign clip to the audioSource
            newAudioSource.clip = audioStems[i];

            if(musicMixerGroup != null)
                newAudioSource.outputAudioMixerGroup = musicMixerGroup;
      
            //add to the audioSources array
            audioSources[i] = newAudioSource;
        }
    }
    
    

    public virtual void StartMusicSystem()
    {
      
    }
    
    public virtual void StopMusicSystem()
    {
        
    }
    
    protected IEnumerator FadeOutMusicSource(AudioSource activeSource, float transitionTime)
    {

        for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (MusicVolumeMax -((t / transitionTime) * MusicVolumeMax));
            yield return null;
        }
        activeSource.mute = true;

        activeSource.volume = MusicVolumeMax;
    }
    
    
    protected IEnumerator FadeInMusicSource(AudioSource activeSource, float transitionTime)
    {
        activeSource.volume = 0.0f;
        activeSource.mute = false;

        for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime) * MusicVolumeMax;
            yield return null;
        }

        activeSource.volume = MusicVolumeMax; 

    }
}
