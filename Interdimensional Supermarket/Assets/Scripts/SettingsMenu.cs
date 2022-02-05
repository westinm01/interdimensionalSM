using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer myMixer;
    public void SetVolume(float input){
        myMixer.SetFloat("MasterVolume", input);
    }
}
