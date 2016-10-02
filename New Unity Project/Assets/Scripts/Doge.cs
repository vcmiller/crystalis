using UnityEngine;
using System.Collections;

public class Doge : Player {
    public GameObject projectile;
    protected override void UseAbility1() {
        GameObject proj = Instantiate(projectile);
        proj.transform.position = transform.position + transform.forward * 2;
        proj.GetComponent<Rigidbody>().velocity = transform.forward * 40;
    }

    protected override void UseAbility2() {
        rb.AddTorque(0, 0, 10, ForceMode.VelocityChange);
    }
}
