using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    [AddComponentMenu("Project/Attraction2D")]
    public class Attraction2D : MonoBehaviour
    {
        [SerializeField] float radius;
        [SerializeField] float force;
        void Start()
        {
        }

        void FixedUpdate()
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D c in col)
            {
                var body = c.GetComponent<Rigidbody2D>();
                if (body != null)
                {
                    Vector2 direction = (Vector2)(gameObject.transform.position) - body.position;
                    var distnsforse = radius - direction.magnitude;
                    distnsforse *= distnsforse / 2;
                    body.AddForce(direction.normalized * distnsforse * force * body.mass * 9.81f, ForceMode2D.Force);
                }
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}