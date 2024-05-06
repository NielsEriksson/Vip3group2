using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    BG,Death,Jump,PickUp,Minimize
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    public AudioClip[] soundArray;
    public Sound sound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        music.clip = Play(Sound.BG);
        music.Play();
    }

    public void PlaySFX(Sound sound)
    {
        //add condition later
        sfx.PlayOneShot(Play(sound));
    }

    public AudioClip Play(Sound sound)
    {
        return soundArray[(int)sound];
    }
}
