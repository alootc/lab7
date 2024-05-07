using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audio_mixer;
    public SaveVolume save_volume;

    public AudioSource music_source;
    public AudioSource sfx_source;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(instance);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeVolume();
    }

    private void Update()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        float value = 0.0001f;

        value = save_volume.master_volumen;
        audio_mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20f);

        value = save_volume.music_volume;
        audio_mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20f);

        value = save_volume.sfx_volume;
        audio_mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20f);
    }

    public void ChangeMusic(AudioClip clip_room)
    {
        music_source.clip = clip_room;

        music_source.Play();
    }

    public void ChangeSFX(AudioClip clip_room)
    {
        music_source.PlayOneShot(clip_room);
    }

}
