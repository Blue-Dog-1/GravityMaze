using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tysseek
{
    [AddComponentMenu("Project/TouchPanel")]
    public class TouchPanel : MonoBehaviour, IDragHandler, IPointerClickHandler
    {
        [SerializeField] float _velocityMoveCam = 1f;
        Camera _camera;
        float diraction;
        void Start()
        {
            _camera = Camera.main;
        }

        void FixedUpdate()
        {
            _camera.transform.position += (Vector3.forward * diraction * _velocityMoveCam);
            diraction = 0;
        }
        public void OnDrag(PointerEventData eventData)
        {
            diraction = Mathf.Clamp((eventData.pressPosition - eventData.position).y * Time.deltaTime, -4f, 4f);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var ray = Camera.main.ScreenPointToRay(eventData.position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000f))
            {
                hit.collider.gameObject.GetComponent<IInteraction>()?.Interaction();
            }

        }
    }
}