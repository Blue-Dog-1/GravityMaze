using System.Collections;
using UnityEngine;

public class WindyStream2D : MonoBehaviour
{
    public float ForceWind;
   
    Collider2D Coll;
    /*
   void OnTriggerStay2D(Collider2D coll) 
   {
        Coll = coll;
        StartCoroutine("Fade");
   }
   */
   void OnTriggerEnter2D(Collider2D coll)
   {
       StartCoroutine(Fade2D(coll));
   }
   void OnTriggerExit2D()
   {
       StopCoroutine("Fade");
   }
   IEnumerator Fade() {
        yield return new WaitForSeconds(0.05f);
        var rb = Coll.gameObject.GetComponent<Rigidbody2D>();
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
        rb.AddForce((vector.normalized * distenc) * ForceWind / rb.mass, ForceMode2D.Force);
    }
    IEnumerator Fade2D(Collider2D collider)
    {
        var rb = collider.gameObject.GetComponent<Rigidbody2D>();
        Vector3 vector;
        float distenc;
        while (true)
        {
            if (rb != null) {
            vector =  rb.transform.position - gameObject.transform.parent.gameObject.transform.position;
            distenc = vector.magnitude;
            distenc = 10 / distenc;
            distenc = distenc * (distenc/2); 
            rb.AddForce((vector.normalized * distenc) * ForceWind / rb.mass, ForceMode2D.Force);
            yield return new WaitForSeconds(0.05f);
            }
            else break;
        }
        yield break;
    }
   
    
}
