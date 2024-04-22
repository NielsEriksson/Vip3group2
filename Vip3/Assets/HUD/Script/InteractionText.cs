using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionText : MonoBehaviour
{
    [SerializeField] private GameObject _object; // object to toggle

    public void ToggleActive()
    {
        if (_object.activeSelf)
            _object.SetActive(false);
        else
            _object.SetActive(false);
    }
}
