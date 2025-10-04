using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HeroInputReader : MonoBehaviour
{
    [SerializeField ]private Hero _hero;

    public void OnMovement (InputAction.CallbackContext context)
    {
        if (_hero == null) return;
        Vector2 movement = context.ReadValue<Vector2>();
      // Debug.Log($"Input received: {direction}");
        _hero.SetDirection(movement);
    }


    public void OnSaySomething (InputAction.CallbackContext context)
    {
        //if (_hero == null) return;
        if (context.canceled)
        {
            _hero.SaySomething();
        }
    }
}
