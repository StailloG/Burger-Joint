using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The script to make the player have a realistic bobbing motion
/// </summary>
public class HeadBob : MonoBehaviour
{
    public float walkingBobbingSpeed = 10f;
    public float bobbingAmount = 0.05f;

    private float defaultPosY = 0;
    private float timer = 0;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.IsMoving())
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}
