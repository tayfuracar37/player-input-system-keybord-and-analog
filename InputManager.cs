using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public  class InputManager : MonoBehaviour
{
    Karakterkontrolleri playerControls;
    public Vector2 movementinput;
    public float horizontalinput;
    public float verticalinput;
    
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new Karakterkontrolleri();
            playerControls.OyuncuHareket.Hareket.performed += i => movementinput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void HandleMoveInput()
    {
        verticalinput = movementinput.y;
        horizontalinput = movementinput.x;
    }

    public void handleAllinput()
    {
        HandleMoveInput();
    }
}
