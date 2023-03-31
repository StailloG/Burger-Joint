using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayIdleAnim()
    {
        anim.SetFloat("Blend", 0.01f);
    }

    public void PlayWalkAnim()
    {
        anim.SetFloat("Blend", 1f);
    }
}
