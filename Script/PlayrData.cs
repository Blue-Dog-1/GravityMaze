using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayrData : MonoBehaviour
{
    public int HP;
    private int _HP;
    public GameObject Massange;
    public Image[] Indicator;
    public bool isProtectiveSphere;
    void Start()
    {  
        _HP = HP;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag != "demethe") return;
        if(!isProtectiveSphere){
        float Velocity = (Mathf.Abs(collision.relativeVelocity.x) + Mathf.Abs(collision.relativeVelocity.y) );
        if (Velocity > 20f){
            HP = HP - ( (int)(Mathf.Round(Velocity)) / 4);
            IndicateHP();
        }
        }
    }
    public void  _OnDestroy()
    {
        Massange.SetActive(true);
        var rigitbodys = FindObjectsOfType<Rigidbody2D>();
        foreach (var item in rigitbodys)
        {
            Destroy(item);
        }
    }
    public void IndicateHP()
    {
        float fillAmount =  HP / 200f;
        Indicator[0].fillAmount = fillAmount;
        Indicator[1].fillAmount = fillAmount;
        if(HP<=0){
            HP=0;
            _OnDestroy();
        }
    }
}
