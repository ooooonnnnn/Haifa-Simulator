using System;
using UnityEngine;

[Tooltip("Prevents to object from moving sideways by applying corrective forces")]
public class SideStabilization : RigidbodyController
{
    private void FixedUpdate()
    {
        var localSideVelocity = transform.InverseTransformVector(rigidbody.linearVelocity).x;
        // print(localSideVelocity);
        rigidbody.AddForce(- localSideVelocity * transform.right, ForceMode.VelocityChange);
    }
}
