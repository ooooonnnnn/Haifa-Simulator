using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CharacterRotation : MonoBehaviour
{
    [SerializeField, HideInInspector] private new Rigidbody rigidbody;
    [SerializeField] private float rotationSpeed;

    private float _input;

    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

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
