using UnityEngine;
using System.Collections;

public class MusicPlay : MonoBehaviour {
    private AudioSource source;
    public AudioClip[] clips;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!source.isPlaying) {
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            source.clip = clip;
            source.Play();
        }
	}
}
