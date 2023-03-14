using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
   [SerializeField] private GameObject stoveOnGameObject;
   [SerializeField] private GameObject particlesGameObject;
   [SerializeField] private StoveCounter stoveCounter;

   private void Start()
   {
      stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
      Hide();
   }

   private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
   {
      switch (e.state)
      {
         case StoveCounter.State.Idle:
            Hide();
            break;
         case StoveCounter.State.Frying:
            Show();
            break;
         case StoveCounter.State.Fried:
            Show();
            break;
         case StoveCounter.State.Burned:
            Hide();
            break;
      }
   }

   private void Show()
   {
      stoveOnGameObject.SetActive(true);
      particlesGameObject.SetActive(true);
   }
   
   private void Hide()
   {
      stoveOnGameObject.SetActive(false);
      particlesGameObject.SetActive(false);
   }
}
