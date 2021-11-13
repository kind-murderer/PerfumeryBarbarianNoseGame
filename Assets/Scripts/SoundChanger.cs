using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChanger : MonoBehaviour
{
    [SerializeField] private AudioClip menuSound;
    [SerializeField] private AudioClip makingPotionsSound;

    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = menuSound;
        audio.Play();
    }

    public void ChangeToMenuSound()
    {
        audio.clip = menuSound;
        audio.Play();
    }
    public void ChangeToMakingPotionsSound()
    {
        audio.clip = makingPotionsSound;
        audio.Play();
    }
}
