using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class RigidbodyController : MonoBehaviour
{
    [SerializeField, HideInInspector] protected new Rigidbody rigidbody;

    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
