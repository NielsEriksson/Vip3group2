using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    [field: SerializeField] UpgradeManagerSO UpgradeManagerSO;

    //Mechanic Upgrade Bools
    [field: SerializeField] public bool left;
    [field: SerializeField] public bool jump;
    [field: SerializeField] public bool doubleJump;
    [field: SerializeField] public bool crouch;
    [field: SerializeField] public bool coins;
    [field: SerializeField] public bool combat;
    [field: SerializeField] public bool enemies;
    [field: SerializeField] public bool obstacles;
    //Customization Upgrade Bools
    [field: SerializeField] public bool backgroundTexture;
    [field: SerializeField] public bool sidescroll;
    [field: SerializeField] public bool platformTexture;
    [field: SerializeField] public bool music;
    [field: SerializeField] public bool sfx;
    [field: SerializeField] public bool playerCustomization;

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
    void Start()
    {
        UpgradeManagerSO.Initiate();
    }
}
