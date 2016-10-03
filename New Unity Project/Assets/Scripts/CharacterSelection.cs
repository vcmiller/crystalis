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

    public Button[] buttons;

    private int player1Choice = -1;

    public int index = 0;
    public bool started = false;

    void Update()
    {
        string s;
        if (player1Choice < 0)
        {
            s = "1";
        } else
        {
            s = "2";
        }

        if (Input.GetButtonDown("Fire2" + s))
        {
            index++;
        }

        if (Input.GetButtonDown("Fire1" + s))
        {
            index--;
        }

        if (index < 0)
        {
            index = 7;
        } else if (index > 7)
        {
            index = 0;
        }

        buttons[index].Select();

        if (Input.GetButtonDown("Restart"))
        {
            choose(index);
        }
    }

    public void choose(int i) {
        if (player1Choice < 0) {
            player1Choice = i;
            text.text = "Player 2\nCHOOSE CHARACTER";
        } else {
            if (!started)
            {
                GetComponent<CanvasGroup>().alpha = 0;
                GetComponent<CanvasGroup>().interactable = false;
                p1spawn.Spawn(player1Choice, p1lives, p1a1, p1a2, "1", p1arrow);
                p2spawn.Spawn(i, p2lives, p2a1, p2a2, "2", p2arrow);
                started = true;
            }
        }
    }
}
