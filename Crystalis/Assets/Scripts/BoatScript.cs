using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour {

    private const float rot_speed = 0.75f;
    private const float vel_speed = 15;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float rot = Input.GetAxis("Horizontal");
        float vel = Input.GetAxis("Vertical");

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(vel * transform.right * vel_speed);
        transform.Rotate(new Vector3(0, 0, rot * rot_speed));

        Debug.Log(rot + " " + vel);
	}
}
