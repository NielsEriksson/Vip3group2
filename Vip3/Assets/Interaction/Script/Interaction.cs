using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    //interaction
    [SerializeField] private string text;

    //Player
    [SerializeField] private string playerTag;
    private bool playerInRange; //is the player in range of the interaction

    //Events
    [SerializeField] private UnityEvent onTriggerInteraction;
    [SerializeField] private UnityEvent onPlayerEnter;
    [SerializeField] private UnityEvent onPlayerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag)) //check if player has entered range and show text & allow interaction if true
        {
            ShowText();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag)) // recrod that player has left range and hdie the text
        {
            HideText();
            playerInRange = false;
        }
    }

    public void TriggerInteraction()
    {
        //Do what is done when interaction is triggered
        if (playerInRange)
        {
            Debug.Log("Interaction triggered");
            onTriggerInteraction?.Invoke();
        }
    }

    private void ShowText()
    {
        onPlayerEnter?.Invoke();
    }

    private void HideText()
    {
        onPlayerExit?.Invoke();
    }
}
