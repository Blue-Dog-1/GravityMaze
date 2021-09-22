using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class Player : MonoBehaviour, IAnnihilated
    {
        [SerializeField] int _hp;
        
        public bool isProtected { get; set; } = false;
        public ProtectiveField protectiveField;


        private void LateUpdate()
        {
            if(protectiveField)
            protectiveField.transform.position = transform.position;
        }
        public void OnHitting()
        {
            gameObject.SetActive(false);
            Debug.Log("the player came out");
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
            GameManager.PlayerDied();
            gameObject.SetActive(false);


        }
    }
}