using UnityEngine;
using System.Collections;
using NoiseTest;

public class Water : MonoBehaviour {
    public Mesh mesh;
    private OpenSimplexNoise noise;

    public float timeScale = .5f;
    public float posScale = 1;
    public float noiseScale = .7f;

	// Use this for initialization
	void Start () {
        noise = new OpenSimplexNoise();
        mesh = GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3[] verts = mesh.vertices;
        for (int i = 0; i < mesh.vertexCount; i++) {
            Vector3 v = verts[i];
            Vector3 pos = v;
            pos.x += transform.position.x;
            pos.y -= transform.position.z;
            v.z = (float)noise.Evaluate(pos.x * posScale, pos.y * posScale, Time.time * timeScale) * noiseScale;
            v.z += (float)noise.Evaluate(pos.x * posScale * .25f, pos.y * posScale * .25f, Time.time * timeScale * .5f) * noiseScale * 2;
            verts[i] = v;
        }
        mesh.vertices = verts;
        mesh.RecalculateNormals();
	}
}
