using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public Mesh[] Meshes;
    public Mesh m_Mesh;

    MeshCollider mc;

    float timer = 0;
    [Range(.4f, 30)]
    public float timeToShift = 1;

    public int mesh_1;
    public int mesh_2;

    public int amountOfMeshes;


    void Start(){
        amountOfMeshes = Meshes.Length;
        mc = GetComponent<MeshCollider>();
        MeshFilter filter = GetComponent(typeof(MeshFilter)) as MeshFilter;

        filter.sharedMesh = Meshes[0];
        m_Mesh = filter.mesh;
    }

    // Update is called once per frame
    void Update() {
        if (true) {

        }
        if (timer < 1) {
            timer += Time.deltaTime / timeToShift;
            if (timer > 1) {
                timer = 1;
            }
        }

        Vector3[] v0 = Meshes[mesh_1].vertices;
        Vector3[] v1 = Meshes[mesh_2].vertices;
        Vector3[] vdst = new Vector3[m_Mesh.vertexCount];
        for (int i = 0; i < vdst.Length; i++) {
            vdst[i] = Vector3.Lerp(v0[i], v1[i], timer);
        }


        m_Mesh.vertices = vdst;
        m_Mesh.RecalculateBounds();

        counter++;
        if (counter > maxCounter) {
            counter = 0;
            mc.sharedMesh = m_Mesh;
        }
    }

    public void ResetTimer(){
        timer = 0;
    }


    int counter;
    int maxCounter = 5;
}
