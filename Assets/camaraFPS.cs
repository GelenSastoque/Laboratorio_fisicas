using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraFPS : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
    }

    public void UpdateMovement(){
        float hor=Input.GetAxisRaw("Horizontal");
        float ver=Input.GetAxisRaw("Vertical");

        if(hor!=0 || ver!=0){
            Vector3 movimiento= (transform.forward*ver+transform.right*hor).normalized*velocidad;
            GetComponent<Rigidbody>().velocity=movimiento;
        }
        else {
            GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        UpdateMovement();

    }
}
