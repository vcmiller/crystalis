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
        GetComponent<MeshFilter>().sharedMesh = Instantiate(GetComponent<MeshFilter>().sharedMesh);
        mesh = GetComponent<MeshFilter>().sharedMesh;

        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3[] verts = mesh.vertices;
        for (int i = 0; i < mesh.vertexCount; i++) {
            Vector3 v = verts[i];
            Vector3 pos = v + transform.position;
            v.y = (float)noise.Evaluate(pos.x * posScale, Time.time * timeScale, pos.z * posScale) * noiseScale;
            //v.y += (float)noise.Evaluate(pos.x * posScale * .25f, pos.z * posScale * .25f, Time.time * timeScale * .5f) * noiseScale * 2;
            verts[i] = v;
        }
        mesh.vertices = verts;
        mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh = mesh;
	}
}
