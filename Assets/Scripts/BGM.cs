using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0.5f;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
