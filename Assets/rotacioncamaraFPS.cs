using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacioncamaraFPS : MonoBehaviour
{
    private Transform camera;
    public Vector2 sensibilidad;
    // Start is called before the first frame update
    void Start()
    {
        camera=transform.Find("Main Camera");
        Cursor.lockState=CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        float hor=Input.GetAxis("Mouse X");
        float ver=Input.GetAxis("Mouse Y");

        if(hor!=0){
            transform.Rotate(Vector3.up*hor*sensibilidad.x);
        }
        if(ver!=0){
            float angulo=(camera.localEulerAngles.x-ver*sensibilidad.y+360)%360;

            if(angulo>180){angulo-=360;}
            angulo=Mathf.Clamp(angulo, -80,80);

            camera.localEulerAngles=Vector3.right*angulo;
        }
    }
}
