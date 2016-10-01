using UnityEngine;
using System.Collections;

public class GlobalController : MonoBehaviour {
    public Material skybox;
    public Material water;

    public float fadeWhite;
    bool starsVisible;
    float starExp;

    float waterProgress = 0;
    bool waterChanging = false;
    public Color waterStartColor;
    public Color waterColor;

    public float timeTilEnd;
    bool end;

    private Light[] lights;

	// Use this for initialization
	void Start () {
        fadeWhite = 0;
        starsVisible = false;
        starExp = 0;
        Water.waterRoughness = 0.15f;
        water.color = waterStartColor;

        lights = GameObject.FindObjectsOfType<Light>();
        skybox.SetFloat("_Exposure", starExp);

        foreach (Light light in lights) {
            light.intensity = 0;
        }

        Invoke("BigBang", .5f);
        Invoke("Stars", 4f);
        Invoke("WaterColor", 20);

        end = false;
         
    }

    void Update() {
        skybox.SetFloat("_Rotation", Time.time * 5);

        timeTilEnd -= Time.deltaTime;
        if(timeTilEnd < 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FuckArtScript>().End();
        }

        foreach (Light light in lights) {
            light.intensity = starExp * .7f;
        }

        if (end)
        {

            starsVisible = false;
            waterChanging = false;

            starExp = Mathf.MoveTowards(starExp, 0.0f, Time.deltaTime * 0.3f);
            skybox.SetFloat("_Exposure", starExp);

        }
        else if (fadeWhite > 0) {
            fadeWhite -= Time.deltaTime * .4f;
        }


        if (starsVisible) {
            starExp = Mathf.MoveTowards(starExp, 1.0f, Time.deltaTime * 0.3f);
            skybox.SetFloat("_Exposure", starExp);
            if (starExp > 1) {
                starsVisible = false;
            }
        }

        if (waterChanging) {
            waterProgress = Mathf.MoveTowards(waterProgress, 1.0f, Time.deltaTime * .1f);
            water.color = Color.Lerp(waterStartColor, waterColor, waterProgress);
        }

    }

    void WaterColor() {
        waterChanging = true;
    }

    void Stars() {

        starsVisible = true;
    }
	
	void BigBang() {
        fadeWhite = 1.5f;
    }

    void OnGUI() {
        if (fadeWhite > 0) {
            GUI.color = new Color(1, 1, 1, fadeWhite);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
    }

    public void End()
    {
        end = true;
    }
}
