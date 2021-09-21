using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tysseek
{
    [AddComponentMenu("Project/TouchPanel")]
    public class TouchPanel : MonoBehaviour, IDragHandler
    {
        [SerializeField] float _velocityMoveCam = 1f;
        Transform _camera;
        float diraction;
        void Start()
        {
            _camera = Camera.main.transform;
        }

        void FixedUpdate()
        {
            _camera.position += (Vector3.forward * diraction * _velocityMoveCam);
            diraction = 0;
        }
        public void OnDrag(PointerEventData eventData)
        {
            diraction = Mathf.Clamp((eventData.pressPosition - eventData.position).y * Time.deltaTime, -4f, 4f);
        }
    }
}