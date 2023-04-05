using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounterAudio : MonoBehaviour
{
  [SerializeField] private AudioSource source;
  [SerializeField] private List<AudioClip> trashClips;



  public void PlayTrashAudio()
  {
    RandomizeAudio();
    AudioClip trashClipToPlay = trashClips[Random.Range(0, trashClips.Count)];
    source.PlayOneShot(trashClipToPlay);
  }

  private void RandomizeAudio()
  {
    source.volume = Random.Range(0.9f, 1.0f);
    source.pitch = Random.Range(0.9f, 1.1f);
  }

}
