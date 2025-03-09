using UnityEngine;

public class Boton_CambiarMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu_ir;
    private GameObject manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate(){
        manager.SendMessage("changeMenu", menu_ir.name);
    }
}
