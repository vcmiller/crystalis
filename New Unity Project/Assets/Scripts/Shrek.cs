using UnityEngine;
using System.Collections;

public class Shrek : Player {
    public GameObject explosion;
    protected override void UseAbility1() {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    protected override void UseAbility2() {
        GetComponent<AudioSource>().Play();
        rb.AddTorque(0, 0, 10, ForceMode.VelocityChange);

        foreach (Player p in FindObjectsOfType<Player>()) {
            if (p != this) {
                transform.position = p.transform.position - p.transform.forward * 3;
            }
        }
    }
}