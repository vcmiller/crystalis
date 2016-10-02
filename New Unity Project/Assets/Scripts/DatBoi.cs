using UnityEngine;
using System.Collections;
using System;

public class DatBoi : Player {
    protected override void UseAbility1() {
        rb.AddForce(transform.forward * 30, ForceMode.VelocityChange);
    }

    protected override void UseAbility2() {
        rb.AddTorque(0, 0, 100, ForceMode.VelocityChange);
    }
}
