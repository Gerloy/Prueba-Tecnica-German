using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu_Salir : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    private EventSystem event_system;
    [SerializeField] private GameObject[] botones;


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
                boton.transform.localScale = new Vector3(1f,1f,1f);
            }else{
                boton.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            }
        }
    }
    public void back(){
        manager.SendMessage("changeMenu", "Principal", SendMessageOptions.DontRequireReceiver);
    }

    public void cambiarBoton(){
        manager.SendMessage("selecBoton", botones[0]);
    }
}
