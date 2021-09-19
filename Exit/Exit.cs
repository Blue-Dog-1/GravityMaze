using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    [AddComponentMenu("Project/Exit")]
    public class Exit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var annihilated = collision.gameObject.GetComponent<IAnnihilated>();
            if (annihilated == null) return;
            annihilated.OnHitting();
        }
    }

    
}