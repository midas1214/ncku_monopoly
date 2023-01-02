using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBGM : MonoBehaviour
{
    AudioSource audioSource;
    private static startBGM instance = null;
    public static startBGM Instance
    {
        get { return instance; }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0.5f;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Awake()
    {
        if (instance !=null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
