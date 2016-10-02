using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpawn : MonoBehaviour {
    public GameObject[] choices;
    public KeyCode[] WASD;
    public KeyCode attack1;
    public KeyCode attack2;
    public Vector3 rotation;

    public void Spawn(int i, Text lives, Image a1, Image a2, string axis, Image arrow) {
        if (i >= choices.Length) {
            i = Random.Range(0, choices.Length);
        }

        GameObject obj = (GameObject) Instantiate(choices[i], transform.position, transform.rotation);
        Player p = obj.GetComponent<Player>();
        p.WASD = WASD;
        p.attack1 = attack1;
        p.attack2 = attack2;
        p.livesCounter = lives;
        p.ability1view = a1;
        p.ability2view = a2;
        p.transform.eulerAngles = rotation;
        p.index = i;
        p.axis = axis;
        p.arrow = arrow;
    }
}
