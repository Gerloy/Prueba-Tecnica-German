using UnityEditor.SearchService;
using UnityEngine;

public class Boton_CambiarScene : MonoBehaviour
{

    [SerializeField] private string escena;
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
        manager.SendMessage("changeScn", escena, SendMessageOptions.DontRequireReceiver);
    }
}
