using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    [SerializeField] private GameObject _object; // object to toggle

    public void ToggleActive()
    {
        if (_object.activeSelf)
            _object.SetActive(false);
        else
            _object.SetActive(true);
    }

    public void SetInactive()
    {
        _object.SetActive(false);
    }

    public void SetActive()
    {
        _object.SetActive(true);
    }
}
