using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum Sound
{
    BG, Death, Jump, PickUp, Minimize,Maximize
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;
    public EnumToAudio enumToAudio;

    bool musicUnlocked;


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
        enumToAudio = gameObject.GetComponent<EnumToAudio>();
        music.clip = Assign(Sound.BG);
        musicUnlocked = false;


    }

    private void Update()
    {
        if (UpgradeManager.Instance.music && !musicUnlocked)
        {
            music.Play();
            musicUnlocked = true;
        }

    }

    public void PlaySFX(Sound sound)
    {
        if(UpgradeManager.Instance.sfx)
         sfx.PlayOneShot(Assign(sound));
    }

    public AudioClip Assign(Sound sound)
    {
        return enumToAudio.audioList[(int)sound];
    }


}
