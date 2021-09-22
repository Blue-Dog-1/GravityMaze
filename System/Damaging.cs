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

        private void OnTriggerEnter2D(Collider2D collision) =>
            ToDamage(collision.gameObject.GetComponent<IAnnihilated>());

        private void OnCollisionEnter2D(Collision2D collision) =>
            ToDamage(collision.gameObject.GetComponent<IAnnihilated>());

        void ToDamage(IAnnihilated annihilated)
        {
            if (annihilated == null) return;

            if (annihilated is Player player)
                if (player.isProtected)
                {
                    StartCoroutine(player.protectiveField.Disactiv(player));
                    return;
                }

            if (!_isAbsolute)
                annihilated.ToDamage(_amountOfDamage);
            else annihilated.Kill();
        }
    }
}