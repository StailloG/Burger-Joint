using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;

    public int index;

    public IntroCoworkerDialogue coworkerDialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        //StartDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coworkerDialogue.inDialogueMode == true)
        {
            ContinueText();
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ContinueText()
    {
        if (dialogueText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }
}
