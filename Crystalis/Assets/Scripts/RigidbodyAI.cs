using UnityEngine;
using System.Collections;

public class RigidbodyAI : MonoBehaviour {
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Vector3 v = transform.forward * 3;
        v.y = 1.0f / transform.position.y;
        rb.velocity = v;
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 v = transform.eulerAngles;
        v.x = rb.velocity.y * -2;
        transform.eulerAngles = v;

        if (transform.position.y < 0) {
            rb.AddForce(Physics.gravity * -2, ForceMode.Acceleration);
        }
	}
}
