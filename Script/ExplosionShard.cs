using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ExplosionShard : MonoBehaviour
{
    public float radius;
    public float force;


    public GameObject[] CollidersGameObject;
    private Rigidbody[] RBArray;
    void Start()
    {
        RBArray = new Rigidbody[CollidersGameObject.Length];
        int namber = 0;
        foreach(GameObject i in CollidersGameObject)
        {
            RBArray[namber] = i.GetComponent<Rigidbody>();
            namber++;
        }
        Invoke("ToExplosion", 5f);
        Invoke("anigelation", 30f);
    }
    void Update()
    {
        
    }
    void ToExplosion()
    {
        foreach(Rigidbody c in RBArray)
        {
            if (c != null)
            c.isKinematic = false;
            c.AddExplosionForce(force, transform.position, radius);
        }
        
    }
    void anigelation()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
