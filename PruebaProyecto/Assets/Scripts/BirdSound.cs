using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSound : MonoBehaviour
{

    public AudioClip birdSound;
    AudioSource sourceSound;

    public bool check;

    // Start is called before the first frame update
    void Start()
    {
        check = false;
        sourceSound = GetComponent<AudioSource>();
        sourceSound.clip = birdSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (check == true)
        {
            sourceSound.Play();
            check = false;
        }
        
    }
   
}
