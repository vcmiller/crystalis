using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public string levelLoad = "Scene";

	public void Play() {
        Application.LoadLevel(levelLoad);
    }

    public void Quit() {
        Application.Quit();
    }
}
