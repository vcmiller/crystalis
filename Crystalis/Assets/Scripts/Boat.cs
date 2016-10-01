using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {
    private Transform camera;

    private Vector3 lastPos;

	// Use this for initialization
	void Start () {
        camera = GetComponentInChildren<Camera>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 4, Vector3.down, out hit)) {//Physics.BoxCast(transform.position + Vector3.up * 4, new Vector3(.6f, .2f, 1.5f), Vector3.down, out hit, Quaternion.identity)) {
            if (hit.transform.gameObject.layer != 4)
            {
                return;
            }

            Vector3 pos = transform.position;
            
            pos.y = hit.point.y;
            transform.position = pos + Vector3.up * .3f;
            Vector3 tilt = hit.normal;//Vector3.RotateTowards(Vector3.up, hit.normal, Vector3.Angle(Vector3.up, hit.normal) * Mathf.Deg2Rad * 0.6f, 0);
            transform.Rotate(Vector3.Cross(transform.up, tilt).normalized, Mathf.Min(Vector3.Angle(transform.up, tilt), Time.deltaTime * 10f), Space.World);

            Vector3 fwd = transform.forward;
            fwd.y = 0;
            fwd = fwd.normalized;
            float d = Vector3.Dot(transform.up, fwd) + .5f;
            d = Mathf.Clamp(d, 0.2f, 1.3f);

            float rot = Input.GetAxis("Horizontal") * 30;
            float vel = Input.GetAxis("Vertical") * 5;

            transform.Translate(transform.forward * vel * d * Time.deltaTime, Space.World);
            transform.Rotate(new Vector3(0, rot * Time.deltaTime , 0), Space.Self);
       

            camera.transform.forward = transform.position - camera.position;
        }else
        {
            RaycastHit hit2;
            if (Physics.Raycast(transform.position - transform.forward + Vector3.up * 4, Vector3.down, out hit2))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, 0.05f);
            }else if(Physics.Raycast(transform.position + transform.forward + Vector3.up * 4, Vector3.down, out hit2))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, 0.05f);
            }
        }

      //  CameraControl();
    }

    void CameraControl() {
        camera.position = Vector3.Lerp(camera.position, transform.position - camera.position, 0.02f);
        camera.position = Vector3.Lerp(camera.position, transform.position + 5 * (-2 * transform.forward + transform.up) + Input.GetAxis("Vertical") * transform.right, 0.12f);
        if(camera.position.y < transform.position.y + 1)
        {
            camera.position = Vector3.Lerp(camera.position, camera.position + Vector3.up, 0.07f);
        }
    }
}
