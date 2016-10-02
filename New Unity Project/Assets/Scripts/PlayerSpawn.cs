using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpawn : MonoBehaviour {
    public GameObject[] choices;
    public KeyCode[] WASD;
    public KeyCode attack1;
    public KeyCode attack2;
    public Vector3 rotation;

    public void Spawn(int i, Text lives) {
        if (i >= choices.Length) {
            i = Random.Range(0, choices.Length);
        }

        GameObject obj = (GameObject) Instantiate(choices[i], transform.position, transform.rotation);
        Player p = obj.GetComponent<Player>();
        p.WASD = WASD;
        p.attack1 = attack1;
        p.attack2 = attack2;
        p.livesCounter = lives;
        p.transform.eulerAngles = rotation;
        p.index = i;
    }
}
