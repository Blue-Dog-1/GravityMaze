using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction2D : MonoBehaviour
{
    public float radius;
    public float force;
    private Vector2 Center;
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
       RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider [] col = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider c in col)
        {
            var r = c.GetComponent<Rigidbody2D>();
            if (r != null){
            Vector3 direction = (Vector2)(gameObject.transform.position) - r.position;
            var distnsforse = radius - direction.magnitude;
            distnsforse *= distnsforse / 2; 
            r.AddForce(direction.normalized * distnsforse * force * r.mass * 9.81f, ForceMode2D.Force);
            RB.AddForce(direction.normalized * distnsforse * r.mass * 9.81f, ForceMode2D.Force);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
