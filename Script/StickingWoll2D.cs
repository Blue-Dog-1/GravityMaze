using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingWoll2D : MonoBehaviour
{
    public int force = 40;
    public int AngularDrag = 50;
    public PhysicMaterial Material;
    private Rigidbody2D RB;
    private Vector3 vector;
    private PhysicsMaterial2D DefauldMaterial;
    bool Flag;
    void Start()
    {
        //RB = gameObject.GetComponent<Rigidbody>();
        vector = Vector3.zero;
        DefauldMaterial = GetComponent<Collider2D>().sharedMaterial;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Flag = true;
        RB = collision.rigidbody;
        vector = -gameObject.transform.up;
        collision.rigidbody.angularDrag = this.AngularDrag;
        //collision.collider.material = Material;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Flag = false;
        collision.rigidbody.angularDrag = 0.05f;
        collision.collider.sharedMaterial = DefauldMaterial;  
    }

    void FixedUpdate()
    {
        if (Flag){
            RB.AddForce(vector * force, ForceMode2D.Force);
            //RB.velocity = Vector3.zero;
        }
    }

}
