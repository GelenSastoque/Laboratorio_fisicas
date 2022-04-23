using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resorte : MonoBehaviour
{
    //void OnMouseDown()
    //{

    //}
    //void OnMouseDrag()
    //{

    //}
    GameObject obj1;
    public float Masa = 0.0f, Elasticidad = 0.0f, Amortiguacion = 0.0f, x = 6.0f, Velocidad_Inicial = 0.0f;
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        obj1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj1.transform.localScale = new Vector3(5 , 5 , 5 );
    }

    // Update is called once per frame
    void Update()
    {
        obj1.transform.position = new Vector3(x, transform.position.y, transform.position.z);
        dibujarlinea();
        x = Velocidad_Inicial * Time.deltaTime + x;
        Velocidad_Inicial = calculos(x, Velocidad_Inicial);
    }

    float calculos(float pos, float v)
    {
        float m1, m2, m3, m4, velocidad, v1, v2, v3, cal1, cal2;
        cal1 = (-Elasticidad * pos) / Masa;
        cal2 = (-Amortiguacion) / (Masa);
        m1 = (cal1 + cal2 * v) * Time.deltaTime;
        v1 = v + (m1 / 2);
        m2 = (cal1 + cal2 * v1) * Time.deltaTime;
        v2 = v + (m2 / 2);
        m3 = (cal1 + cal2 * v2) * Time.deltaTime;
        v3 = v + m3;
        m4 = (cal1 + cal2 * v3) * Time.deltaTime;
        velocidad = v + (m1 / 6) + (m2 / 3) + (m3 / 3) + (m4 / 6);
        return velocidad;
    }
    void dibujarlinea()
    {
        Color c1 = Color.red;
        Color c2 = new Color(1, 1, 1, 0);
        
        Vector3 startingPoint = new Vector3(21.1f, 61.4f, -2.4f);
        Vector3 endPoint = new Vector3(x, 61.4f, -2.4f);
        line.SetPosition(0, startingPoint);
        line.SetPosition(1, endPoint);
        //line.startColor(c1);
    }

}
