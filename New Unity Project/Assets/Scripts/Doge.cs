using UnityEngine;
using System.Collections;

public class Doge : Player {
    protected override void UseAbility1() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3)) {
            Rigidbody otherBody = hit.collider.GetComponent<Rigidbody>();
            if (otherBody != null) {
                otherBody.AddForce(transform.forward * 30, ForceMode.VelocityChange);
            }
        }
    }

    protected override void UseAbility2() {
        rb.AddTorque(0, 0, 10, ForceMode.VelocityChange);
    }
}
