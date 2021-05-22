using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int Demage;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        var playrData = obj.gameObject.GetComponent<PlayrData>();
        if (playrData != null && !playrData.isProtectiveSphere){
            float Velocity = (Mathf.Abs(obj.relativeVelocity.x) + Mathf.Abs(obj.relativeVelocity.y) );
                playrData.HP -= (int)(Velocity) * Demage;
                playrData.IndicateHP();
            
        }
    }
}
