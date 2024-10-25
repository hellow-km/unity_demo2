using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCotroller : MonoBehaviour
{
    private PlayerInputActions inputActions;

    public event EventHandler onInteraceEvent;


    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.Player.interace.performed += Interace_performed;
    }

    private void Interace_performed(InputAction.CallbackContext obj)
    {
        onInteraceEvent?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 getMoveVector()
    {
        Vector2 move = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 newVelocity = Vector3.zero;
        if (move.x != 0 || move.y != 0)
        {
            newVelocity = new Vector3(move.x, 0, move.y);
        }
        return newVelocity;
    }


    public bool isJump()
    {
        return inputActions.Player.Jump.ReadValue<float>() > 0;
    }
}
