using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public Vector3 p1;
    public Vector3 p2;
    public float time;

	// Use this for initialization
	void Start () {
        transform.position = p1;
	}
	
	// Update is called once per frame
	void Update () {
        float f = Mathf.Sin(Time.time * Mathf.PI / time) * 0.5f + 0.5f;
        transform.position = Vector3.Lerp(p1, p2, f);
	}
}
