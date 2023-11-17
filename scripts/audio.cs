using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip Background;
    
    private void Start(){
        musicSource.clip = Background;
        musicSource.Play();
    }
}
