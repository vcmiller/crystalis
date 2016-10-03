using UnityEngine;
using System.Collections;
using System;

public class Harambe : Player {
    protected override void UseAbility1() {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 2.0f, other.transform.position - transform.position, out hit, 4)) {
            Rigidbody otherBody = hit.collider.GetComponent<Rigidbody>();
            if (otherBody != null) {
                otherBody.AddForce((transform.forward + Vector3.up * 0.2f) * 30, ForceMode.VelocityChange);
            }
        }
    }

    protected override void UseAbility2() {
        rb.AddTorque(0, 0, 10, ForceMode.VelocityChange);
    }
}
