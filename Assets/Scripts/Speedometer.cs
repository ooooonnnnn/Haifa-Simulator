using System;
using UnityEngine;
using UnityEngine.Events;

[Tooltip("Reports the speed of the object")]
[RequireComponent(typeof(Rigidbody))]
public class Speedometer : MonoBehaviour, INumericProperty
{
    public UnityEvent<float> OnSpeedChanged;
    private float _speed;
    [SerializeField, HideInInspector] private new Rigidbody rigidbody;

    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public float GetNumericPropertyValue() => _speed;

    private void FixedUpdate()
    {
        _speed = rigidbody.linearVelocity.magnitude;
        OnSpeedChanged.Invoke(_speed);
    }
}
