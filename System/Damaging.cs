using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class Damaging : MonoBehaviour
    {
        [SerializeField] bool _isAbsolute;
        [SerializeField] int _amountOfDamage;

        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var annihilated = collision.gameObject.GetComponent<IAnnihilated>();
            if (annihilated == null) return;

            if (annihilated is Player player)
            {
                if (player.isProtected) return;
            }

            if (!_isAbsolute)
                annihilated.ToDamage(_amountOfDamage);
            else annihilated.Kill();
        }
    }
}