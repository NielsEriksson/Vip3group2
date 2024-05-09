using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnumToAudio : MonoBehaviour
{
    [Header("Enums")]
    [SerializeField] public List<AudioClip> audioList = new List<AudioClip>();
   
    private void OnValidate()
    {
        // Update audioList to match the number of enum values
        UpdateAudioList();
    }

    private void UpdateAudioList()
    {
        int enumCount = Enum.GetNames(typeof(Sound)).Length;

        // Ensure audioList matches the number of enum values
        while (audioList.Count < enumCount)
        {
            audioList.Add(null); // Add placeholders for new enum values
        }
        while (audioList.Count > enumCount)
        {
            audioList.RemoveAt(audioList.Count - 1); // Remove excess items
        }
    }

}
