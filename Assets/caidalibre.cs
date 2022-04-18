using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caidalibre : MonoBehaviour
{
    private float densidad = 1.2041f, area = 0.002f  , velocidad = 0.0f;
    public float coefric1=0.0f, gravedad = 9.81f, masa = 0.09f, y = 20.0f, veloinicial = 0.0f;
    private float calconst, tiempo = 0.0f;

    public void asignarcoefric(string c)
    {

        coefric1 = 0.0f;
        coefric1 = float.Parse(c);
        if (coefric1 > 3)
        {
            coefric1 = 3;
        }
    }
    void Start()
    {
        tiempo = 0.1f;
        calconst = (densidad * area * coefric1) / (2 * masa);
    }
    // Update is called once per frame
    void Update()
    {
        float yaux = y;
        if(yaux>0)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            y = y + veloinicial * tiempo;
            veloinicial = RungeKutta(veloinicial);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            //Destroy(gameObject);
        }
    }

    float RungeKutta(float v)
    {
        float m1, m2, m3, m4, v1, v2, v3;
        m1 = ((-gravedad) + (calconst * Mathf.Pow(v, 2))) * tiempo;
        v1 = v + (m1 / 2);
        m2 = ((-gravedad) + (calconst * Mathf.Pow(v1, 2))) * tiempo;
        v2 = v + (m2 / 2);
        m3 = ((-gravedad) + (calconst * Mathf.Pow(v2, 2))) * tiempo;
        v3 = v + m3;
        m4 = ((-gravedad) + (calconst * Mathf.Pow(v3, 2))) * tiempo;
        velocidad = v + (m1 / 6) + (m2 / 3) + (m3 / 3) + (m4 / 6);

        return velocidad;
    }
}
