using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
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
        else buttonPlay.interactable = false;
        
    }

    public void Scrollig(bool scroll)
    {
        isScrolling = scroll; 
        if (scroll) scrollRect.inertia = true;
    }
    public void PlayLayer()
    {   
        
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


