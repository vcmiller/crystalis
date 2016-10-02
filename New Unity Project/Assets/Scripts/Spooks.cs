using UnityEngine;
using System.Collections;

public class Spooks : Player {
    public MeshRenderer eye1;
    public MeshRenderer eye2;

    protected override void UseAbility1() {
        eye1.enabled = true;
        eye2.enabled = true;

        Invoke("DisableEyes", 4);
        rb.mass = 3;
    }

    protected override void UseAbility2() {
        GetComponent<AudioSource>().Play();

        foreach (Player p in FindObjectsOfType<Player>()) {
            if (p != this) {
                p.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 5, 0, ForceMode.VelocityChange);
            }
        }
    }

    public void DisableEyes() {
        eye1.enabled = false;
        eye2.enabled = false;
        rb.mass = 1;
    }
}
