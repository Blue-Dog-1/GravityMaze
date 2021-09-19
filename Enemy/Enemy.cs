using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class Enemy : MonoBehaviour, IAnnihilated
    {
        [SerializeField] int _hp;

        public void OnHitting()
        {
            gameObject.SetActive(false);
            Debug.LogFormat("The enemy '{0}' came out", gameObject.name);
            GameManager.OnHitting(this);
        }
        public void ToDamage(int amountOfDamage)
        {
            _hp -= amountOfDamage;
            if (_hp <= 0)
            {
                _hp = 0;
                Kill();
            }
        }
        public void Kill()
        {
            gameObject.SetActive(false);
            GameManager.EnemyDied();
        }
    }
}