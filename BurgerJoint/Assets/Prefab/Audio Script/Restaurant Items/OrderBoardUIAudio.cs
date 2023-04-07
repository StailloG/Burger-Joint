using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBoardUIAudio : MonoBehaviour
{
   [SerializeField] private AudioSource source;
[Header("Audio source is on the text object since its in world space")]
   [SerializeField] private AudioClip newOrderClip;
   [SerializeField] private AudioClip orderCompleteClip;


   public void PlayNewOrderClip()
   {
      source.PlayOneShot(newOrderClip);
   }
   
   public void PlayOrderCompleteClip()
   {
      source.PlayOneShot(orderCompleteClip);
   }

}
