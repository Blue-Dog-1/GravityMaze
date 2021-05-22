using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject Ball;
    public GameObject RotateToll;
    private Vector3 deltaPosition;
    
    public GameObject wolls;
    void Start()
    {
        deltaPosition = Ball.transform.position;
        deltaPosition.z = transform.position.z;
        Physics2D.gravity = Vector3.down * 9.81f;
    }

    void FixedUpdate()
    {
        deltaPosition.x = Ball.transform.position.x;
        deltaPosition.y = Ball.transform.position.y;
        
        /*
        deltaPosition = Ball.transform.position - deltaPosition;
        Camera.main.transform.Translate(deltaPosition, Space.World);
        deltaPosition = Ball.transform.position;
        */

        Camera.main.transform.position = Vector3.Lerp( transform.position, deltaPosition, 0.3f);

        /*
         вращение камеры и вектора гравитации for PC {
        */
        if (Input.GetKey(KeyCode.A)){
            RotateToll.transform.RotateAround(Ball.transform.position, Vector3.back, 5f);

            //wolls.transform.RotateAround(Vector2.zero, Vector3.forward, 5f);
            
           // rect.Rotate(Vector3.back * 5f, Space.World);
            Physics2D.gravity = -RotateToll.transform.up * 9.81f;
        }
        if (Input.GetKey(KeyCode.D)){
            RotateToll.transform.RotateAround(Ball.transform.position, Vector3.forward, 5f);

            //wolls.transform.RotateAround(Vector2.zero, Vector3.back, 5f);
           // rect.Rotate(Vector3.forward * 5f, Space.World);
            Physics2D.gravity = -RotateToll.transform.up * 9.81f;
        }
        
        // }  
    }
}
