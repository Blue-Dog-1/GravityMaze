using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Compass : MonoBehaviour
{
    public GameObject Plyar;
    public GameObject target;
    public GameObject compass;
    Vector3 vectorarrow;
    Vector3 vectortarget;
    RectTransform rect;
    Quaternion tmpQuat;
    
    void Start()
    {
        rect = compass.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        vectortarget =  Plyar.transform.position - target.transform.position;
        vectortarget.z = 0f;
        rect.rotation = Quaternion.FromToRotation(Camera.main.transform.up, - vectortarget);
    }
}

