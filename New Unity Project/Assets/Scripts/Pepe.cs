using UnityEngine;
using System.Collections;

public class Pepe : Player {
    private bool ree = false;
    protected override void UseAbility1() {
        ree = true;
        Invoke("StopRee", 5);
        thrust = 15;
        GetComponent<AudioSource>().Play();
    }

    public void StopRee() {
        ree = false;
        thrust = 10;
    }

    protected override void UseAbility2() {
        rb.AddTorque(0, 0, 10, ForceMode.VelocityChange);
    }

    void OnGUI() {
        if (ree) {
            GUI.color = new Color(1, 0, 0, .3f);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
    }
}
