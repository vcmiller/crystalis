using UnityEngine;
using System.Collections;

public class FuckArtScript : MonoBehaviour {

    Vector3 ogPos;
    bool end;

	// Use this for initialization
	void Start () {
        ogPos = transform.position;
        end = false;
        transform.position -= 500 * Vector3.down;
	}
	
	// Update is called once per frame
	void Update () {
        if (end)
        {
            transform.position = Vector3.Lerp(transform.position, ogPos, 0.2f);
            transform.rotation = Random.rotation;
        }
	}

    public void End()
    {
        end = true;
    }
}
