using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Menu_Manager : MonoBehaviour
{

    private PlayerInput input;
    [SerializeField]private GameObject submenu;
    [SerializeField] private GameObject canvas;
    private GameObject event_system;
    void Start()
    {
        input = gameObject.GetComponent<PlayerInput>();
        submenu = canvas.transform.Find("Fondo/Principal").gameObject;
        event_system = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeScn(String scene){
        SceneManager.LoadScene(scene);
    }

    public void changeMenu(String sm_go){
        submenu.SetActive(false);
        submenu = canvas.transform.Find("Fondo/"+sm_go).gameObject;
        submenu.SetActive(true);
        submenu.SendMessage("cambiarBoton");
    }
    public void selecBoton(GameObject boton){
        event_system.GetComponent<EventSystem>().SetSelectedGameObject(boton);
    }
}
