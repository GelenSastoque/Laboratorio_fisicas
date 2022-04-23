using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceder_Caida : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }

    }
}
