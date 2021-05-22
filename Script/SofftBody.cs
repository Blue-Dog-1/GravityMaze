using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofftBody : MonoBehaviour
{

    public Mesh mesh;
    public Vector3[] vertices;
    public int CenterPoint;
    public int verticesCaunt;
    public List<GameObject> points;
    public GameObject tobeIstanted;

    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticesCaunt = vertices.Length;

        for (int i=0; i < vertices.Length; i++){
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
