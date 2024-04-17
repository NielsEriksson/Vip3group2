using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpriteState
{
    Bright, Dark, Night, Spooky
}

public class SpriteChangeManager : MonoBehaviour
{
    public static SpriteChangeManager Instance;


    public SpriteState spriteState;
    // Start is called before the first frame update

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
