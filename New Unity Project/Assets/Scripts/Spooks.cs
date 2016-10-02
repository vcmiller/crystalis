using UnityEngine;
using System.Collections;

public class Spooks : Player {
    public AudioClip doot;
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
        AudioSource.PlayClipAtPoint(doot, Camera.main.transform.position);

        foreach (Player p in FindObjectsOfType<Player>()) {
            if (p != this) {
                p.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 5, 0, ForceMode.VelocityChange);
            }
        }
    }
}
