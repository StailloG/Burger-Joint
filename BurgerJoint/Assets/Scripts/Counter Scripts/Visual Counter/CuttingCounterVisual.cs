using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
   private const string CUT = "Cut";
   private Animator animator;
   [SerializeField] private CuttingCounter cuttingCounter;
   private void Awake()
   {
      animator = GetComponent<Animator>();
   }

   private void Start()
   {
      cuttingCounter.OnCut += CuttingContainer_OnCut;
   }

   private void CuttingContainer_OnCut(object sender, EventArgs e)
   {
      
      animator.SetTrigger(CUT);
   }
}
