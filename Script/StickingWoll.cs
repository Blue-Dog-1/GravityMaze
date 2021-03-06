using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingWoll : MonoBehaviour
{
    public int force = 40;
    public int AngularDrag = 50;
    public PhysicMaterial Material;
    private Rigidbody RB;
    private Vector3 vector;
    private PhysicMaterial DefauldMaterial;
    bool Flag;
    void Start()
    {
        //RB = gameObject.GetComponent<Rigidbody>();
        vector = Vector3.zero;
        DefauldMaterial = GetComponent<Collider>().material;
    }
    void OnCollisionEnter(Collision collision)
    {
        
        Flag = true;
        RB = collision.rigidbody;
        vector = -gameObject.transform.up;
        collision.rigidbody.angularDrag = this.AngularDrag;
        collision.collider.material = Material;
        
    }
    void OnCollisionExit(Collision collision)
    {
        Flag = false;
        collision.rigidbody.angularDrag = 0.05f;
        collision.collider.material = DefauldMaterial;  
    }

    void FixedUpdate()
    {
        if (Flag){
            RB.AddForce(vector * force, ForceMode.Force);
            //RB.velocity = Vector3.zero;
        }
    }

}
