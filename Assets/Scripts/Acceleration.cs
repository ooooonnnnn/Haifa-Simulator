using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Acceleration : RigidbodyController
{
    [SerializeField] private float acceleration;

    private float verticalInput;
    
    [Tooltip("Takes the forward component of the move input and accelerates the rigidbody")]
    public void Accelerate(InputAction.CallbackContext ctx)
    {
        verticalInput = ctx.ReadValue<Vector2>().y;
        print(verticalInput);
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(verticalInput * acceleration * transform.forward);
    }
}
