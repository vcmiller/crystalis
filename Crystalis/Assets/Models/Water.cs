using UnityEngine;
using System.Collections;
using NoiseTest;

public class Water : MonoBehaviour {
    public Mesh mesh;
    private static OpenSimplexNoiseTileable3D noise;
    private static OpenSimplexNoiseTileable3D noise2;

    public float timeScale = .5f;
    public float posScale = 1;
    public float noiseScale = .7f;

    const int repeat = 20 / 6;
    const float ratio = repeat / (20.0f / 6.0f);


    const int repeat2 = 1;
    const float ratio2 = 6.0f / 20.0f;

    private static bool meshUpdated = false;

    private void updateMesh() {
        Vector3[] verts = mesh.vertices;
        for (int i = 0; i < mesh.vertexCount; i++) {
            Vector3 v = verts[i];
            //Vector3 pos = v + transform.position;

            //v.y = sampleNoise(v.x + 10, Time.time * timeScale, v.y + 10);

            v.y = (float)noise.eval(v.x * ratio, Time.time * timeScale, v.z * ratio) * noiseScale;
            v.y += (float)noise2.eval(v.x * ratio2, Time.time * timeScale * 0.25f, v.z * ratio2) * noiseScale * 2;
            verts[i] = v;
        }
        mesh.vertices = verts;
        mesh.RecalculateNormals();
    }

	// Use this for initialization
	void Start () {

        if (noise == null) {
            noise = new OpenSimplexNoiseTileable3D(repeat, repeat, repeat);
            noise2 = new OpenSimplexNoiseTileable3D(repeat2, repeat2, repeat2);
        }

        mesh = GetComponent<MeshFilter>().sharedMesh;

        gameObject.AddComponent<MeshCollider>().sharedMesh = mesh;
    }
	
	// Update is called once per frame
	void Update () {
        if (!meshUpdated) {
            updateMesh();
            meshUpdated = true;
        }

        Boat boat = FindObjectOfType<Boat>();

        Vector3 p = boat.transform.position;
        Vector3 me = transform.position;
        if (p.x >= me.x - 10 && p.x <= me.x + 10 && p.z >= me.z - 10 && p.z <= me.z + 10) {
            gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        }


    }

    void LateUpdate() {
        meshUpdated = false;
    }
}
