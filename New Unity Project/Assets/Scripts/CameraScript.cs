using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public Transform harambe;
    public Transform datBoi;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Player[] players = FindObjectsOfType<Player>();
        if (players.Length > 1) {
            Vector3 v = transform.position;
            Vector3 a = players[0].transform.position + players[1].transform.position;
            a /= 2;
            v.x = a.x;
            v.y = a.y;
            v.z = -Mathf.Max(Vector3.Distance(players[0].transform.position, players[1].transform.position), 5);
            transform.position = v;
        }
	}
}
