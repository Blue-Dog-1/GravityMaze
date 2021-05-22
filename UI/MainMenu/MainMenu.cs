using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public LevelData LevelData;
    [Range(1, 50)]
    [Header("Controlles")]
    [SerializeField]
    public int panCaunt;
    [Range(1, 500)]
    public int panOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Header("other Object")]
    public GameObject panPrefab;
    public Button buttonPlay;
    public GameObject[] intPans;
    private Vector2[] pansPos;
    private Vector2[] pansScale;
    [Range(0f, 5f)]
    public float scaleOffset;
    [Range(0f, 20f )]
    public float scaleSpeed;
    private RectTransform contentRect;
    [SerializeField]
    private int selelctPanID;
    private bool isScrolling;
    public ScrollRect scrollRect;
    private Vector2 contentVector;
    public GameObject ParentR;
    public GameObject ButtonStart;
    public Slider loadingImg;
    
    void Start()
    {
        Time.timeScale = 1f;
        
        
        contentRect = GetComponent<RectTransform>(); 
        intPans = new GameObject[panCaunt];
        pansPos = new Vector2[panCaunt];
        pansScale = new Vector2[panCaunt];
        for (int i = 0; i < panCaunt; i++)
        {
            intPans[i] = Instantiate(panPrefab, transform, false);
            intPans[i].GetComponent<Image>().sprite = LevelData.image[i];
            intPans[i].transform.GetChild(0).gameObject.SetActive(!LevelData.isUnlocked[i]);
            intPans[i].transform.GetChild(1).gameObject.SetActive(LevelData.isUnlocked[i]);
            if (LevelData.scoring[i] > 0)
            intPans[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = LevelData.scoring[i].ToString();
            if (i == 0) continue;
            intPans[i].transform.localPosition = new Vector2(intPans[i-1].transform.localPosition.x + panPrefab.GetComponent<RectTransform>().sizeDelta.x + panOffset, 
                intPans[i].transform.localPosition.y);
            pansPos[i] = -intPans[i].transform.localPosition; 
            
        }
     
    }

    private void FixedUpdate()
    {
        if (contentRect.anchoredPosition.x >= pansPos[0].x && !isScrolling || contentRect.anchoredPosition.x <= pansPos[pansPos.Length - 1].x && !isScrolling)
            scrollRect.inertia = false;
        float narestPos = float.MaxValue;
        for (int i = 0; i < panCaunt; i++)
        {
            float distence = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);
            if (distence < narestPos)
            {
                narestPos = distence;
                selelctPanID = i;
            }
            float scale = Mathf.Clamp(1 / (distence / panOffset) * scaleOffset, 0.5f, 1f); 
            pansScale[i].x = Mathf.SmoothStep(intPans[i].transform.localScale.x, scale, scaleSpeed * Time.fixedDeltaTime);
            pansScale[i].y = Mathf.SmoothStep(intPans[i].transform.localScale.y , scale, scaleSpeed * Time.fixedDeltaTime);
            intPans[i].transform.localScale = pansScale[i];
        }
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;

        if (isScrolling || scrollVelocity > 400) return;
        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selelctPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;

        if(LevelData.isUnlocked[selelctPanID] && Application.CanStreamedLevelBeLoaded("level" + (selelctPanID)))
        buttonPlay.interactable = true;
        else buttonPlay.interactable = false;
        
    }

    public void Scrollig(bool scroll)
    {
        isScrolling = scroll; 
        if (scroll) scrollRect.inertia = true;
    }
    public void PlayLayer()
    {   
        try{
        
        if (LevelData.isUnlocked[selelctPanID])
            //SceneManager.LoadScene(LevelData.nameLavel[selelctPanID], LoadSceneMode.Single);
            StartCoroutine(AsyncLoad());
        }
        catch{
            Debug.Log("error");
        }
    }
    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelData.nameLavel[selelctPanID]);
        loadingImg.gameObject.transform.parent.gameObject.SetActive(true);
        while (!operation.isDone)
        {
            float progress = operation.progress;// / 0.9f;
            loadingImg.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }
    public void StartAnimation()
    {
        ParentR.GetComponent<Animation>().Play();
        ButtonStart.GetComponent<Animation>().Play();
        buttonPlay.gameObject.GetComponent<Animation>().Play();
        Invoke("r", 0.8f);
    }
    public void r()
    {
        Destroy(ButtonStart);
    }
}


