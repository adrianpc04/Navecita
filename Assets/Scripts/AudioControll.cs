using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControll : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioMixer mixer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Time.timeScale == 0)
        {
            mixer.SetFloat("LowpassFreq", 500);
        }
        else
        {
            mixer.SetFloat("LowpassFreq", 22000);
        }
    }
}
