using System;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private enum Estado{
        IDLE=0,
        ARRIBA=1,
        ABAJO=2
    }

    //Cosas del movimiento
    [SerializeField] private float vel;
    private Vector2 mov_input;
    private Vector2 mov;
    private PlayerInput input;

    //Cosas del disparo
    [SerializeField] private GameObject _disparo;
    private bool power_up;
    private Estado estado;
    private float time_d;
    [SerializeField] private float cooldown_d;
    private bool puede_disparar;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        power_up = false;
        time_d = 0;
        puede_disparar = true;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        GetComponent<Rigidbody2D>().linearVelocity = mov_input * vel;

        if (mov_input.y < 0){
            estado = Estado.ABAJO;
        }else if (mov_input.y > 0){
            estado = Estado.ARRIBA;
        }else {
            estado = Estado.IDLE;
        }

        GetComponent<Animator>().SetInteger("state", (int) estado);

        if(!puede_disparar){
            if(time_d < cooldown_d){
                time_d += Time.deltaTime;
            }else{
                puede_disparar = true;
            }
        }

    }

    public void move(InputAction.CallbackContext context){
        mov_input = input.actions["move"].ReadValue<Vector2>();
    }

    public void disparar(InputAction.CallbackContext context){
        if(puede_disparar){
            GameObject disparo = Instantiate(_disparo);
            disparo.transform.position = transform.position;
            if (power_up){
                disparo.GetComponent<Disparo>().estado = Disparo.Estado.TIRO_POWERUP;
                
            }else{
                disparo.GetComponent<Disparo>().estado = Disparo.Estado.TIRO_NORMAL;
            }
            puede_disparar = false;
            time_d = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Enemigo"){
            if (!power_up){
                GameObject.Find("Manager").SendMessage("perder");
            }else {power_up = false;}
        }else if (collision.gameObject.tag == "PowerUp"){
            GameObject.Find("Manager").SendMessage("sumarPuntos", 600);
            power_up = true;
            Destroy(collision.gameObject);
        }
    }
}
