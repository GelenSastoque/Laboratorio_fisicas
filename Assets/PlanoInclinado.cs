using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanoInclinado : MonoBehaviour
{
    public float Coeficiente_Rozamiento = 0.0f, masa = 0.0f, velocidad_inicial=0.0f;
    private float Angulo = -14.86f, gravedad = 9.81f, peso = 0.0f, normal=0.0f, friccion=0.0f, peso_X=0.0f, aceleracion=0.0f, h=0.1f,aceleracion_x=0.0f,aceleracion_y=0.0f;
    private float vel_x = 0.0f,vel_y;
    private float x= 0.0f, y= 20.05f;
    // Start is called before the first frame update
    void Start()
    {
        peso = masa * gravedad;
        Angulo = (Angulo * Mathf.PI) / 180.0f;
        normal = peso * Mathf.Cos(Angulo);
        friccion = Coeficiente_Rozamiento * normal;
        peso_X = peso * Mathf.Sin(Angulo);
        aceleracion = (peso_X - friccion) / masa;
        aceleracion_x = aceleracion * Mathf.Cos(Angulo);
        aceleracion_y = aceleracion * Mathf.Sin(Angulo);
        vel_x = velocidad_inicial + aceleracion_x * h;
        vel_y=velocidad_inicial - aceleracion_y * h;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, y, transform.position.z);
       if(x<=0 &&x>-68)
        {
            movimiento();
        }
        else if (x<-68&&x>-130)
        {
            movrectiliniounif(vel_x);
        }
    }
    void movimiento()
    {
        float velocidad=0.0f;
        velocidad = Mathf.Sqrt(Mathf.Pow(vel_x, 2) + Mathf.Pow(vel_y, 2));
        vel_x = vel_x + aceleracion_x * h;
        vel_y = vel_y - aceleracion_y * h;
        x = x + vel_x * h;
        y = y + vel_y * h;
    }
    void movrectiliniounif(float v1)
    {
        //vx = -vx;
        x = v1 * h + x;
    }
}
