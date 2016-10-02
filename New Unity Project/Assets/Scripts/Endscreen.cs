using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour {
    public Sprite[] icons;
    private int winIndex = -1;
    private int loseIndex = -1;
    private bool gameOver = false;

    CanvasGroup group;

    public Image loser;
    public Image winner;

    public void setOver(int win, int lose) {
        winIndex = win;
        loseIndex = lose;

        loser.overrideSprite = icons[lose];
        winner.overrideSprite = icons[win];

        group = GetComponent<CanvasGroup>();
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
        gameOver = true;
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.R) && gameOver) {
            Time.timeScale = 1.0f;
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
