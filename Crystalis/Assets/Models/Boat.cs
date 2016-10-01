using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 4, Vector3.down, out hit)) {//Physics.BoxCast(transform.position + Vector3.up * 4, new Vector3(.6f, .2f, 1.5f), Vector3.down, out hit, Quaternion.identity)) {
            
            
            Vector3 pos = transform.position;
            pos.y = hit.point.y;
            transform.position = pos;
            transform.up = Vector3.RotateTowards(transform.up, hit.normal, Time.deltaTime * .15f, 0);
        }


	}
}
