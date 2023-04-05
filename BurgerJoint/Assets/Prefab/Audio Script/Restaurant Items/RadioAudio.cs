using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;

   [SerializeField] private List<AudioClip> radioSegments;

    private float timer = 0.0f;

    private const float newRadioSegmentTime = 35f; 
    // Start is called before the first frame update
    void Start()
    {
        if (!source) source = GetComponent<AudioSource>();
        timer = 27f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > newRadioSegmentTime)
        {
            source.PlayOneShot(radioSegments[Random.Range(0, radioSegments.Count)]);
            timer = 0;
        }
    }
}
