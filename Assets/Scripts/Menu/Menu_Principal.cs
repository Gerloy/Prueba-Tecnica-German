using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu_Principal : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    private EventSystem event_system;
    [SerializeField] private GameObject[] botones;
    private int boton_actual;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        event_system = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject boton in botones){
            if(boton.name == event_system.currentSelectedGameObject.name){
                boton.transform.localScale = new Vector3(0.65f,0.65f,0.65f);
            }else{
                boton.transform.localScale = new Vector3(0.54f,0.54f,0.54f);
            }
        }
    }

    public void activate(){
        botones[boton_actual].SendMessage("activate", SendMessageOptions.DontRequireReceiver);
    }
    public void back(){
        manager.SendMessage("changeMenu", "Salir", SendMessageOptions.DontRequireReceiver);
    }

    public void cambiarBoton(){
        manager.SendMessage("selecBoton", botones[0]);
    }

}
