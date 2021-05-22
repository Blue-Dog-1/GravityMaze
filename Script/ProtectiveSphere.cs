using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectiveSphere : MonoBehaviour
{
    protected float radius;
    private float SelfRadius;
    void Start()
    {
        SelfRadius = GetComponent<CircleCollider2D>().radius;
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
       var playrData =  collider.gameObject.GetComponent<PlayrData>();
       
       if (playrData != null){
            playrData.isProtectiveSphere = true;
            radius = collider.gameObject.GetComponent<CircleCollider2D>().radius;
            collider.gameObject.GetComponent<CircleCollider2D>().radius *= SelfRadius;
            Destroy(gameObject); 
       }
    }



}
