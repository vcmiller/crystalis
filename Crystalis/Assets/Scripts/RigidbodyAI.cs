using UnityEngine;
using System.Collections;

public class RigidbodyAI : MonoBehaviour {
    Rigidbody rb;
    Waypoint waypoint;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (waypoint != null) {
            if (Vector3.SqrMagnitude(transform.position - waypoint.transform.position) < 4) {
                waypoint = waypoint.next;
                return;
            }
        }

        Vector3 v = transform.eulerAngles;
        v.x = rb.velocity.y * -2;
        transform.eulerAngles = v;

        if (transform.position.y < 0) {
            rb.AddForce(Physics.gravity * -2, ForceMode.Acceleration);
        }
	}
}
