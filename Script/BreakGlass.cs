using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.Break
{
public class BreakGlass : MonoBehaviour
{
   public int ForceHit;
   public int ForceHitForSplinter;
   public GameObject GlassDestroyVersion;
   public GameObject PS;
   private ParticleSystem PartSys;
   private Collision Coll;
   void Start()
   {
      PartSys = PS.GetComponent<ParticleSystem>();
      StartCoroutine("g");

   }
   void OnCollisionEnter(Collision collision)
   {
      Coll = collision;
      BreakShard.VectorForce = collision.relativeVelocity;
      StartCoroutine("f");
   }
   void DestroyGlassWholeVersion()
   {
      Destroy(gameObject);
      GlassDestroyVersion.SetActive(true);
   }
   IEnumerator f()
   {
      float Velocity = (Mathf.Abs(Coll.relativeVelocity.x) + Mathf.Abs(Coll.relativeVelocity.y) + Mathf.Abs(Coll.relativeVelocity.z));
      float ForceHit = Coll.rigidbody.mass * Velocity;
      if (ForceHit >= this.ForceHit) {
      //PartSys.Play();
      DestroyGlassWholeVersion(); 
      }
      yield return null;
   }
   IEnumerator g()
   {
      yield return new WaitForSeconds(0.45f);
      PartSys.Pause();
   }

}
}
