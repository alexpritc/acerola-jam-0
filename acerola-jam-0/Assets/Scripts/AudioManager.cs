using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;

    private int masterVol = 1;
    private int musicVol = 1;
    private int sfxVol = 1;

    // Start is called before the first frame update
    void Start()
    {
        UpdateVolumes();
    }

    void UpdateVolumes()
    {
        mixer.SetFloat("masterVol", masterVol);
        mixer.SetFloat("musicVol", musicVol);
        mixer.SetFloat("sfxVol", sfxVol);
    }

    public void UpdateMasterVolume()
    {
        mixer.SetFloat("masterVol", masterVol);
    }

    public void UpdateMusicVolume()
    {
        mixer.SetFloat("musicVol", musicVol);
    }
    public void UpdateSFXVolume()
    {
        mixer.SetFloat("sfxVol", sfxVol);
    }
}
