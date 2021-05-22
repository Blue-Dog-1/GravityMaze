using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Explosion : MonoBehaviour
{
    public float radius;
    public float force;
    private Rigidbody2D RB;
    
    Vector3 vectorToObj;
    Collider2D [] coll;
    void Start()
    {
        
        //Invoke("ToExplosion", 3f);
    }
    void Update()
    {   
        coll  = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D c in coll){
        
            RaycastHit2D HitInfo = Physics2D.Linecast(transform.position, c.transform.position);
            if (HitInfo.rigidbody  != null){
            Debug.DrawLine(transform.position, c.transform.position, Color.red, HitInfo.distance);
            Debug.Log(HitInfo.collider.gameObject.name);
            }
            
        }
        
    }
    void ToExplosion()
    {
        Collider2D [] col = Physics2D.OverlapCircleAll(transform.position, radius);
        float relevativForce;
        foreach(Collider2D c in col)
        {
            RB = c.GetComponent<Rigidbody2D>();
            if (RB == null) continue;
            //RB.AddExplosionForce(force, transform.position, radius);
            vectorToObj = c.gameObject.transform.position - transform.position;
            RaycastHit2D _Hit = Physics2D.Raycast(transform.position, vectorToObj.normalized, radius);
            if (_Hit.rigidbody != null ) {
            relevativForce = radius - vectorToObj.magnitude;
            relevativForce = Mathf.Clamp(relevativForce, 1f, radius - 5f);
            RB.AddForce(vectorToObj.normalized * relevativForce * force, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
