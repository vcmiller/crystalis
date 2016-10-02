using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour {
    public KeyCode[] WASD;
    public KeyCode attack1;
    public KeyCode attack2;
    protected Rigidbody rb;
    Vector3 start;
    Quaternion startRot;
    public int lives;
    public Text livesCounter;
    public CooldownTimer ability1;
    public CooldownTimer ability2;
    public float thrust = 7;
    public int index;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        start = transform.position;
        startRot = transform.rotation;
        livesCounter.text = "Lives: " + lives;
        rb.maxAngularVelocity = 100;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(WASD[0])) {
            rb.AddForce(Vector3.up * thrust, ForceMode.VelocityChange);
        } else if (Input.GetKeyDown(WASD[1])) {
            rb.AddForce(Vector3.left * thrust, ForceMode.VelocityChange);
        } else if (Input.GetKeyDown(WASD[2])) {
            rb.AddForce(Vector3.down * thrust, ForceMode.VelocityChange);
        } else if (Input.GetKeyDown(WASD[3])) {
            rb.AddForce(Vector3.right * thrust, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(attack1) && ability1.Use) {
            UseAbility1();
        }

        if (Input.GetKeyDown(attack2) && ability2.Use) {
            UseAbility2();
        }

        if (rb.velocity.magnitude > 30) {
            rb.velocity = rb.velocity.normalized * 30;
        }

        Vector3 v = transform.position;
        v.z = 0;
        transform.position = v;

        if (transform.position.y < -4) {
            transform.position = start;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.rotation = startRot;

            lives--;
            livesCounter.text = "Lives: " + lives;

            if (lives <= 0) {
                Player[] players = FindObjectsOfType<Player>();
                foreach (Player player in players) {
                    if (player != this) {
                        FindObjectOfType<Endscreen>().setOver(player.index, index);
                        return;
                    }
                }
            }
        }
	}

    protected abstract void UseAbility1();
    protected abstract void UseAbility2();
    
}
