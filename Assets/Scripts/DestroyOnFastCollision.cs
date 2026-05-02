using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof(Collider))]
public class DestroyOnFastCollision : MonoBehaviour, INumericProperty
{
    [SerializeField] private float speedThreshold;
    
    [Tooltip("Triggered on collision, passed with relative velocity of the two bodies")]
    public UnityEvent<Vector3> OnAnyCollision;
    public UnityEvent<Vector3> OnFastCollision;

    public float GetNumericPropertyValue() => speedThreshold;

    private void OnCollisionEnter(Collision collision)
    {
        var collisionRelativeVelocity = collision.relativeVelocity;
        
        OnAnyCollision.Invoke(collisionRelativeVelocity);

        if (collisionRelativeVelocity.sqrMagnitude > speedThreshold * speedThreshold)
        {
            OnFastCollision.Invoke(collisionRelativeVelocity);
            Destroy(gameObject);
        }
    }
}