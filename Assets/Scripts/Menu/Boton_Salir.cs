using System;
using UnityEngine;

public class Boton_Salir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate(){
        Debug.Log("Salio");
        Application.Quit();
    }
}
