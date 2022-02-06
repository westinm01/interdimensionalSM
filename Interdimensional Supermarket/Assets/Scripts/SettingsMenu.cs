using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer myMixer;
    public AudioSource mySource;
    public AudioClip playSound;
    public AudioClip buttonSound;
    public void SetVolume(float input){
        myMixer.SetFloat("MasterVolume", input);
    }

    public void PlayPlaySound(){
        mySource.clip = playSound;
        mySource.Play();
    }

    public void PlayButtonSound(){
        mySource.clip = buttonSound;
        mySource.Play();
    }
}
