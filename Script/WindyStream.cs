using System.Collections;
using UnityEngine;

public class WindyStream : MonoBehaviour
{
    public float ForceWind;
    Collider Coll;
   void OnTriggerStay(Collider coll)
   {
        Coll = coll;
        StartCoroutine("Fade");
   }
   void OnTriggerExit()
   {
       StopCoroutine("Fade");
   }
   IEnumerator Fade() {
        yield return new WaitForSeconds(0.05f);
        var rb = Coll.gameObject.GetComponent<Rigidbody>();
        var vector =  rb.transform.position - gameObject.transform.parent.gameObject.transform.position;
        var distenc = vector.magnitude;/*
        distenc = Mathf.Round(distenc);
        distenc = distenc * (distenc / 10);
        Debug.Log(100 / (distenc * rb.mass));
        Debug.Log(rb.velocity);
        */
        
        //rb.AddForce((vector.normalized / (distenc * rb.mass)) * ForceWind, ForceMode.Acceleration);

        distenc = 10 / distenc;
        distenc = distenc * (distenc/2);
        rb.AddForce( (vector.normalized * distenc) * ForceWind / rb.mass, ForceMode.Force);
    }
   
    
}
