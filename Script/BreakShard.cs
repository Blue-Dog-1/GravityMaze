using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.Break
{
public class BreakShard : MonoBehaviour
{

  public int ForceHit;
  public static Vector3 VectorForce;
  private Rigidbody Rigidbody;
  private ParticleSystem PartSys;
  public float HP = 530f;
  void Start()
  {
     PartSys = transform.GetChild(0).GetComponent<ParticleSystem>();
     StartCoroutine("g");
     //GetComponent<Rigidbody>().AddForce(VectorForce, ForceMode.VelocityChange);
     Rigidbody = GetComponent<Rigidbody>();
  }
 
  void OnCollisionEnter(Collision collision)
  {
    float Velocity = (Mathf.Abs(collision.relativeVelocity.x) + Mathf.Abs(collision.relativeVelocity.y) + Mathf.Abs(collision.relativeVelocity.z));
    HP = HP - Velocity; 
    if (Velocity >= ForceHit) DestroyGlassWholeVersion(); 
    Debug.Log(Velocity);
  }
  void DestroyGlassWholeVersion()
  {
    Rigidbody.isKinematic = false;
    PartSys.Play();
    if (HP <= 0f)
    Destroy(gameObject);
  }
  IEnumerator g()
   {
      yield return new WaitForSeconds(0.45f);
      PartSys.Pause();
   }
}
}
