using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public float radius;
    public float force;
    private Vector3 Center;
    private Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
       RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider [] col = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider c in col)
        {
            var r = c.GetComponent<Rigidbody>();
            if (r != null){
            Vector3 direction = gameObject.transform.position - r.position;
            var distnsforse = radius - direction.magnitude;
            distnsforse *= distnsforse / 2; 
            r.AddForce(direction.normalized * distnsforse * force * r.mass * 9.81f, ForceMode.Force);
            RB.AddForce(direction.normalized * distnsforse * r.mass * 9.81f, ForceMode.Force);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
