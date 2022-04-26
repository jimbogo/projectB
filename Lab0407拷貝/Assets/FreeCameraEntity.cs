using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraEntity : MonoBehaviour
{
    float VELOCITY = 10f;
    Vector3 m_MousePostion;

    float m_HorizontalAngle = 0;
    float m_VerticalAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        // move forward and backward camera 預設朝向正y
        if(Input.GetKey(KeyCode.D)){
            // this.transform.Translate(VELOCITY * Time.deltaTime, 0, 0);
            movement += Vector3.right;

        }else if(Input.GetKey(KeyCode.A)){
            // this.transform.Translate(-VELOCITY * Time.deltaTime, 0, 0);
            movement -= Vector3.right;
        }

        // move right and left
        if(Input.GetKey(KeyCode.W)){
            // this.transform.Translate(0, 0, VELOCITY * Time.deltaTime );
            movement += Vector3.forward;
        }else if(Input.GetKey(KeyCode.S)){
            // this.transform.Translate(0, 0, -VELOCITY * Time.deltaTime );
            movement += Vector3.back;
        }

        if(movement != Vector3.zero){
            movement.Normalize();
            this.transform.Translate(movement * VELOCITY * Time.deltaTime);
        }

        // mouse 

        if(Input.GetMouseButtonDown(0)){
            m_MousePostion = Input.mousePosition;
        }else if(Input.GetMouseButton(0)){
            Vector3 mouseDeltaPostion = m_MousePostion - Input.mousePosition;

            m_HorizontalAngle -= mouseDeltaPostion.x * 0.1f;
            m_VerticalAngle = Mathf.Clamp(m_VerticalAngle - mouseDeltaPostion.y * 0.1f, -89f, 89f);

            this.transform.localEulerAngles = new Vector3 (0f, m_HorizontalAngle ,m_VerticalAngle);

            m_MousePostion = Input.mousePosition;
        }
    }
}
