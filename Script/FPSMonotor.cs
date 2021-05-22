using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSMonotor : MonoBehaviour
{

    public Text outFPS;
    private int FPS;
    private bool init;
    void Start()
    {
        FPS = 0;
        StartCoroutine("second");

    }

    void Update()
    {
        FPS++;
        if (init) StartCoroutine("second");
        init = false;
    }
    IEnumerator second()
    {
        yield return new WaitForSeconds(1);
        outFPS.text = "FPS " + FPS;
        FPS = 0;
        init = true;
    }
}
