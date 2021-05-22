using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticking : MonoBehaviour
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
        RB = gameObject.GetComponent<Rigidbody>();
        vector = Vector3.zero;
        DefauldMaterial = GetComponent<Collider>().material;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "StickyWalls"){
        Flag = true;
        vector = -collision.contacts[0].normal;
        gameObject.GetComponent<Rigidbody>().angularDrag = this.AngularDrag;
        gameObject.GetComponent<Collider>().material = Material;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "StickyWalls"){
        Flag = false;
        gameObject.GetComponent<Rigidbody>().angularDrag = 0.05f;
        gameObject.GetComponent<Collider>().material = DefauldMaterial;
        }       
    }

    void FixedUpdate()
    {
        if (Flag){
            RB.AddForce(vector * force, ForceMode.Force);
            //RB.velocity = Vector3.zero;
        }
    }

}
