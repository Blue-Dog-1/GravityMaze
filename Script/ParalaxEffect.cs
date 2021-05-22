using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    Vector2 vector;
    public float paralaxHorizomple;
    public float paralaxVerticle;
    Transform cam;
    float[] Startpos = new float[2];
    public Material _material;
    float e;
    void Start()
    {
        cam = Camera.main.gameObject.transform;
        Startpos[0] = transform.localPosition.x;
        Startpos[1] = transform.localPosition.y;
    }
    void Update()
    {
        vector = (Vector2)(cam.position) - Vector2.zero;
        e = vector.magnitude;
        vector.Normalize();
        vector.x = vector.x * e;
        vector.y = 0f;

        _material.SetVector("OffsetVelue", vector);
    }
}
