using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class Player : MonoBehaviour, IAnnihilated
    {
        [SerializeField] int _hp;
        [SerializeField] TrailRenderer _trail;
        public bool isProtected { get; set; } = false;
        public ProtectiveField protectiveField;
        
        Rigidbody2D _rb;
        public void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void LateUpdate()
        {
            if(protectiveField)
            protectiveField.transform.position = transform.position;
        }
        private void OnEnable()
        {
            _trail.gameObject.SetActive(true);
            if (_rb == null)
                _rb = GetComponent<Rigidbody2D>();
            ResetPhysics();
        }
        public void ResetPhysics()
        {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0;
        }
        void OnDisable()
        {
            _trail.gameObject.SetActive(false);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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