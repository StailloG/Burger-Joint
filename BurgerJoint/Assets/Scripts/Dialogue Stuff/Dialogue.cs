using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI textComponent;
   public string[] lines; //convert this into a scriptable object
   [SerializeField] private float textSpeed;
   private int index;

   private void Start()
   {
     
      textComponent.text = string.Empty;
   }


   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         if (textComponent.text == lines[index])
         {
            NextLine();
         }
         else
         {
            StopAllCoroutines();
            textComponent.text = lines[index];
         }
      }
   }

   void StartDialogue()
   {
      if (lines == null) return;
      index = 0;
      StartCoroutine(TypeLine());
   }

   void StartDialogue(string dialogueText)
   {
      lines = new string[1];
      lines[0] = dialogueText;
      StartCoroutine(TypeLine());
   }

   IEnumerator TypeLine()
   {
      foreach (char c in lines[index].ToCharArray())
      {
         textComponent.text += c;
         yield return new WaitForSeconds(1/textSpeed);
      }
   }

   void NextLine()
   {
      if (index < lines.Length - 1)
      {
         index++;
         textComponent.text = String.Empty;
         StartCoroutine(TypeLine());
      }
      else
      {
         gameObject.SetActive(false);
      }
   }
}
