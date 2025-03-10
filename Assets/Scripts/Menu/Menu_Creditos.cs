using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu_Creditos : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    private EventSystem event_system;
    [SerializeField] private GameObject boton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        event_system = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void back(){
        manager.SendMessage("changeMenu", "Principal", SendMessageOptions.DontRequireReceiver);
    }

    public void cambiarBoton(){
        manager.SendMessage("selecBoton", boton);
    }
}
