using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        Destroy(this, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other) {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
