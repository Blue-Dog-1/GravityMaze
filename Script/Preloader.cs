using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Preloader : MonoBehaviour
{
    // Start is called before the first frame update
    public int scenID;
    public Slider loadingImg;
    void Start()
    {
        StartCoroutine(AsyncLoad());
    }
    IEnumerator AsyncLoad()
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImg.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
