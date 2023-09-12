using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static CustomInput;

public class NewBehaviourScript : ScriptableObject, IPlayerActions
{
    CustomInput customInput;
    private void OnEnable()
    {
        if (customInput == null) 
        {
            customInput = new CustomInput();
        }
        customInput.Player.SetCallbacks(this);
        customInput.Enable();
    }
    public Action<Vector2> MoveEvent;
    public Action ShootEvent;
    public Action CancleShootEvent;
    public Action ReplaceWeaponEvent;
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnReplaceWeapon(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            ReplaceWeaponEvent?.Invoke();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ShootEvent?.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            CancleShootEvent?.Invoke();
        }
    }
}
