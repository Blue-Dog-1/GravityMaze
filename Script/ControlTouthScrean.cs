using UnityEngine;
using UnityEngine.EventSystems;

public class ControlTouthScrean : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject RotateToll;
    private Vector2 position;
    private float width;
    void Start()
    {
        width = transform.parent.gameObject.GetComponent<RectTransform>().rect.width;
        
        
        width = width / 2;
    }

    // Update is called once per frame
    void FixidUpdate()
    {
        
    }
    public void OnPointerDown (PointerEventData eventData)
    {
       position = eventData.pressPosition;
       //OnDrag(eventData);
       
    }
    public void OnPointerUp (PointerEventData eventData)
    {
       
    }
    public void OnDrag (PointerEventData eventData)
    {   
        if (Input.touchCount != 1) return; 
        if (eventData.position.x > width)
            Camera.main.transform.Rotate(Vector3.forward * (position.y - eventData.position.y) * 0.3f, Space.World);
        else 
            Camera.main.transform.Rotate(Vector3.forward * (eventData.position.y - position.y) * 0.3f, Space.World);
        
        position = eventData.position;
        Physics.gravity = -Camera.main.transform.up * 9.81f;
        
    }

    
}
