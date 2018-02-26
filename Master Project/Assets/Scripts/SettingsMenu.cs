using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu2 : MonoBehaviour {

    public AudioMixer audioMixer;
    float sharedVolume;

	public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        sharedVolume = volume;
    }

    public void mute()
    {
        audioMixer.SetFloat("volume", -80);
    }

    public void unmute()
    {
        audioMixer.SetFloat("volume", sharedVolume);
    }
}
