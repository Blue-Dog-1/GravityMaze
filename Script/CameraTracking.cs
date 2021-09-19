using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class CameraTracking : MonoBehaviour
    {
        [SerializeField] Transform Player;
        private Vector3 deltaPosition;

        void Start()
        {
            deltaPosition = Player.position;
            deltaPosition.z = transform.position.z;
            Physics2D.gravity = Vector3.down * 9.81f;
        }

        void FixedUpdate()
        {
            deltaPosition.x = Player.position.x;
            deltaPosition.y = Player.position.y;

            Camera.main.transform.position = Vector3.Lerp(transform.position, deltaPosition, 0.3f);
        }
    }
}