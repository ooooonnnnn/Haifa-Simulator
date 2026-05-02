using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterRotation : RigidbodyController
{
    [SerializeField] private float rotationSpeed;

    private float _input;

    public void Rotate(InputAction.CallbackContext ctx) => _input = ctx.ReadValue<Vector2>().x;

    private void FixedUpdate()
    {
        // transform.Rotate(
        //     0,
        //     _input * rotationSpeed * Time.fixedDeltaTime,
        //     0);
        
        rigidbody.MoveRotation(
            rigidbody.rotation * Quaternion.Euler(0, _input * rotationSpeed * Time.fixedDeltaTime, 0));
    }
}
