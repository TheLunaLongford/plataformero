using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_box : MonoBehaviour
{

    public AudioClip complete_level;
    public AudioClip damage;
    public AudioClip jump;
    public AudioClip menu;

    private AudioSource audio_source;

    private void Start()
    {
        audio_source = GetComponent<AudioSource>();
        audio_source.playOnAwake = false;
    }

    public void play_damage()
    {
        audio_source.clip = damage;
        audio_source.Play();
    }

    public void play_jump()
    {
        audio_source.clip = jump;
        audio_source.Play();
    }

    public void play_complete_level()
    {
        audio_source.clip = complete_level;
        audio_source.Play();
    }

    public void play_menu()
    {
        audio_source.clip = menu;
        audio_source.Play();
    }
}
