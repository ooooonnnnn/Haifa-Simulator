using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof(Collider))]
public class DestroyOnFastCollision : MonoBehaviour
{
    [SerializeField] private float speedThreshold;
    
    [Tooltip("Triggered on collision, passed with relative velocity of the two bodies")]
    public UnityEvent<Vector3> OnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        var collisionRelativeVelocity = collision.relativeVelocity;
        OnCollision.Invoke(collisionRelativeVelocity);

        if (collisionRelativeVelocity.sqrMagnitude > speedThreshold * speedThreshold)
            Destroy(gameObject);
    }
}
