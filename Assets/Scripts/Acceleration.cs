using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Acceleration : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField, HideInInspector] private new Rigidbody rigidbody;

    private float verticalInput;
    
    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    [Tooltip("Takes the forward component of the move input and accelerates the rigidbody")]
    public void Accelerate(InputAction.CallbackContext ctx)
    {
        verticalInput = ctx.ReadValue<Vector2>().y;
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(verticalInput * acceleration * transform.forward);
    }
}
