using UnityEngine;
using System.Collections;

public class Sanic : Player {
    protected override void UseAbility1() {
        transform.position = new Vector3(Random.Range(-25, 25), Random.Range(0, 40), 0);
    }

    protected override void UseAbility2() {
        rb.AddTorque(0, 0, 30, ForceMode.VelocityChange);
    }
}
