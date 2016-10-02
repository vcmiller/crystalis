using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {
    public Text text;

    public PlayerSpawn p1spawn;
    public PlayerSpawn p2spawn;

    public Image p1a1;
    public Image p1a2;
    public Image p2a1;
    public Image p2a2;

    public Text p1lives;
    public Text p2lives;

    public Image p1arrow;
    public Image p2arrow;

    private int player1Choice = -1;

    public void choose(int i) {
        if (player1Choice < 0) {
            player1Choice = i;
            text.text = "Player 2\nCHOOSE CHARACTER";
        } else {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<CanvasGroup>().interactable = false;
            p1spawn.Spawn(player1Choice, p1lives, p1a1, p1a2, "1", p1arrow);
            p2spawn.Spawn(i, p2lives, p2a1, p2a2, "2", p2arrow);
        }
    }
}
