using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class Enemy : MonoBehaviour, IAnnihilated
    {
        public static List<Enemy> enemies = new List<Enemy>();
        [SerializeField] int _hp;
        [SerializeField] TrailRenderer _trail;

        Rigidbody2D _rb;
        public void Start()
        {
            enemies.Add(this);
            _rb = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            if (_rb == null)
                _rb = GetComponent<Rigidbody2D>();
            _trail.gameObject.SetActive(true);
        }
        void OnDisable()
        {
            _trail.gameObject.SetActive(false);
            ResetPhysics();
        }
        public void ResetPhysics()
        {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0;
        }
        public void OnHitting()
        {
            gameObject.SetActive(false);
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