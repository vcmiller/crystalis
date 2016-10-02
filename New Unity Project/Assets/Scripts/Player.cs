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
    public string axis;

    public Image ability1view;
    public Image ability2view;

    public Image arrow;

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
        ability1view.fillAmount = (Time.time - ability1.LastUse) / ability1.Cooldown;
        ability2view.fillAmount = (Time.time - ability2.LastUse) / ability2.Cooldown;


        if (Input.GetKeyDown(WASD[0])) {
            rb.AddForce(Vector3.up * thrust, ForceMode.VelocityChange);
        } else if (Input.GetKeyDown(WASD[1])) {
            rb.AddForce(Vector3.left * thrust, ForceMode.VelocityChange);
        } else if (Input.GetKeyDown(WASD[2])) {
            rb.AddForce(Vector3.down * thrust, ForceMode.VelocityChange);
        } else if (Input.GetKeyDown(WASD[3])) {
            rb.AddForce(Vector3.right * thrust, ForceMode.VelocityChange);
        }

        rb.AddForce(Vector3.right * thrust * 4 * Input.GetAxis("Horizontal" + axis), ForceMode.Acceleration);
        rb.AddForce(Vector3.down * thrust * 4 * Input.GetAxis("Vertical" + axis), ForceMode.Acceleration);

        if ((Input.GetKeyDown(attack1) || Input.GetButtonDown("Fire1" + axis)) && ability1.Use) {
            UseAbility1();
        }

        if ((Input.GetKeyDown(attack2) || Input.GetButtonDown("Fire2" + axis)) && ability2.Use) {
            UseAbility2();
        }

        if (rb.velocity.magnitude > 30) {
            rb.velocity = rb.velocity.normalized * 30;
        }

        Vector3 v = transform.position;
        v.z = 0;
        transform.position = v;

        if (transform.position.y < -4) {
            die();
        }

        UpdateArrow();
	}

    private void die() {
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

    void UpdateArrow() {
        arrow.enabled = true;

        Vector3 p = Camera.main.WorldToScreenPoint(transform.position);
        if (p.x > 0 && p.y > 0 && p.x < Screen.width && p.y < Screen.height) {
            arrow.transform.position = p + new Vector3(0, 64, 0);
            arrow.transform.eulerAngles = new Vector3(0, 0, 180);
        } else {
            Vector3 d = p - new Vector3(Screen.width, Screen.height) / 2;
            d = d.normalized * (Screen.height / 2 - 64);
            arrow.transform.position = new Vector3(Screen.width, Screen.height) / 2 + d;
            arrow.transform.up = d;
        }
    }

    void OnCollisionEnter(Collision col) {
        Rigidbody otherBody = col.collider.GetComponent<Rigidbody>();
        if (otherBody != null) {
            otherBody.AddForce((otherBody.transform.position - transform.position).normalized * rb.angularVelocity.magnitude * 0.5f, ForceMode.VelocityChange);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Finish")) {
            die();
        }
    }
    

    protected abstract void UseAbility1();
    protected abstract void UseAbility2();
    
}
