using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tysseek
{
    [AddComponentMenu("Project/InputHub")]
    public class InputHub : MonoBehaviour
    {
        [SerializeField] UI.Button _left;
        [SerializeField] UI.Button _right;


        public System.Action left;
        public System.Action right;


        private void Start()
        {
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.A) || _left.isPressed)
                left?.Invoke();

            if (Input.GetKey(KeyCode.D) || _right.isPressed)
                right?.Invoke();
        }


        private void LateUpdate()
        {
        }



    }
}
