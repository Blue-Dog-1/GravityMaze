using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class CameraTracking : MonoBehaviour
    {
        [SerializeField] Transform _player;
        private Vector3 deltaPosition;
        void Start()
        {
            deltaPosition = _player.position;
            deltaPosition.z = transform.position.z;
        }

        void FixedUpdate()
        {
            deltaPosition.x = _player.position.x;
            deltaPosition.y = _player.position.y;

            transform.position = Vector3.Lerp(transform.position, deltaPosition, 0.3f);
        }
    }
}