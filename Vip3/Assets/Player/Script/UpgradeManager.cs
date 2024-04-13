using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private bool left;
    [SerializeField] private bool jump;
    [SerializeField] private bool doubleJump;
    [SerializeField] private bool crouch;

    public bool Left { get { return left; } }
    public bool Jump { get { return jump; } }
    public bool DoubleJump { get { return doubleJump; } }
    public bool Crouch { get { return crouch; } }

    public void UnlockLeft()
    {
        left = true;
    }

    public void UnlockJump()
    {
        jump = true;
    }

    public void UnlockDoubleJump()
    {
        doubleJump = true;
    }

    public void UnlockCrouch()
    {
        crouch = true;
    }
}
