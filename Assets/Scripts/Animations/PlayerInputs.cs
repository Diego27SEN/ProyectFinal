using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public InputSystem_Actions inputs;


    public Action<Vector2> OnMoveChange;

    private Vector2 moveInput;

    private void Awake()
    {
       
        if (inputs == null)
            inputs = new InputSystem_Actions();
    }

    private void OnEnable()
    {
    
        inputs.Enable();

  
        inputs.Player.Move.started += OnMove;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        if (inputs != null && inputs.bindingMask != null || inputs != null)
        {
            inputs.Player.Move.started -= OnMove;
            inputs.Player.Move.performed -= OnMove;
            inputs.Player.Move.canceled -= OnMove;
        }

        inputs.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        OnMoveChange?.Invoke(moveInput);
    }

    
    public Vector2 MoveInput => moveInput;
}
