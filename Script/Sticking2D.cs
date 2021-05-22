using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticking2D : MonoBehaviour
{
    public int force = 40;
    public int AngularDrag = 50;
    public PhysicMaterial Material;
    private Rigidbody2D RB;
    private Vector2 vector;
    private PhysicMaterial DefauldMaterial;
    bool Flag;
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        vector = Vector3.zero;
        //DefauldMaterial = GetComponent<Collider2D>().
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = AngularDrag;
        collision.gameObject.GetComponent<Rigidbody2D>().drag = 15f;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Flag = false;
        collision.GetComponent<Rigidbody2D>().gravityScale = 1f;
        collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = 0.05f;
        collision.gameObject.GetComponent<Rigidbody2D>().drag = 0f;
    }

    

}
