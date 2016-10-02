using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {
    public Text text;

    public PlayerSpawn p1spawn;
    public PlayerSpawn p2spawn;

    public Text p1lives;
    public Text p2lives;

    private int player1Choice = -1;

    public void choose(int i) {
        if (player1Choice < 0) {
            player1Choice = i;
            text.text = "Player 2\nCHOOSE CHARACTER";
        } else {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<CanvasGroup>().interactable = false;
            p1spawn.Spawn(player1Choice, p1lives);
            p2spawn.Spawn(i, p2lives);
        }
    }
}
