using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    PlayerInput playerI;
    void OnEnable()
    {
        playerI = new PlayerInput();
        if (playerI != null)
        {
            //add in attack here once I am ready.
            playerI.PlayerAction.LeftRight.started += (val) => PlayerMovement.Instance.LeftRight(val.ReadValue<float>());
            playerI.PlayerAction.UpDown.started += (val) => PlayerMovement.Instance.UpDown(val.ReadValue<float>());
            playerI.PlayerAction.UpDown.canceled += (val) => PlayerMovement.Instance.UpDownFinished();
            playerI.PlayerAction.LeftRight.canceled += (val) => PlayerMovement.Instance.LeftRightFinished();

        }
        playerI.Enable();
    }

    private void OnDisable()
    {
        playerI.Disable();
    }
}