using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    BG, Death, Jump, PickUp, Minimize
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    public AudioClip[] soundArray;
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
        return soundArray[(int)sound];
    }
}
