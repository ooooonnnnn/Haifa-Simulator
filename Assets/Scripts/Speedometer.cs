using System;
using UnityEngine;
using UnityEngine.Events;

[Tooltip("Reports the speed of the object")]
public class Speedometer : RigidbodyController, INumericProperty
{
    public UnityEvent<float> OnSpeedChanged;
    private float _speed;

    public float GetNumericPropertyValue() => _speed;

    private void FixedUpdate()
    {
        _speed = rigidbody.linearVelocity.magnitude;
        OnSpeedChanged.Invoke(_speed);
    }
}
