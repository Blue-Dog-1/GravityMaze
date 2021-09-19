using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class Compass : MonoBehaviour
    {
        public GameObject Plyar;
        public GameObject target;
        public GameObject compass;
        Vector3 vectortarget;
        RectTransform rect;

        void Start()
        {
            rect = compass.GetComponent<RectTransform>();
        }

        void Update()
        {
            if (target)
            {
                vectortarget = Plyar.transform.position - target.transform.position;
                vectortarget.z = 0f;
                rect.rotation = Quaternion.FromToRotation(Camera.main.transform.up, -vectortarget);
            }
        }
    }
}