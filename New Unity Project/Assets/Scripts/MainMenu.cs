using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void Play(string levelLoad) {
        Application.LoadLevel(levelLoad);
    }

    public void Quit() {
        Application.Quit();
    }
}
