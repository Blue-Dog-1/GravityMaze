using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class Compass : MonoBehaviour
    {
        [SerializeField] Transform _playar;
        [SerializeField] Transform _target;
        Vector3 vectortarget;
        
        public void SetTarget(Transform target, Transform player)
        {
            _target = target;
            _playar = player;
        }

        void Update()
        {
            if (_target)
            {
                vectortarget = _playar.transform.position - _target.transform.position;
                vectortarget.z = 0f;
                transform.rotation = Quaternion.FromToRotation(Camera.main.transform.up, -vectortarget);
            }
        }
    }
}