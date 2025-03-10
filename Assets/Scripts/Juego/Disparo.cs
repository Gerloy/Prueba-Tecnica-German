using Unity.VisualScripting;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int tipo = 4;

    private Animator animator;
    [SerializeField] private float vel;
    [SerializeField] private Sprite[] explosion;
    [SerializeField] private Sprite[] tiro_comun;
    [SerializeField] private Sprite[] tiro_power;
    private float time_ani;
    [SerializeField] private float cool_frame;
    private int frame;

    public enum Estado{
        TIRO_NORMAL = 0,
        TIRO_POWERUP = 1,
        EXPLOTA = 2,
    };

    public Estado estado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        frame = 0;
        time_ani = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocityX = vel;
        GetComponent<Rigidbody2D>().linearVelocityY = 0;

        //Animaciones
        switch(estado){
            case Estado.TIRO_NORMAL:
                if(time_ani < cool_frame){
                    time_ani += Time.deltaTime;
                }else{
                    frame++;
                    time_ani = 0;
                }
                if(frame >= tiro_comun.Length){frame = 0;}
                GetComponent<SpriteRenderer>().sprite = tiro_comun[frame];
                break;
            case Estado.TIRO_POWERUP:
                if(time_ani < cool_frame){
                    time_ani += Time.deltaTime;
                }else{
                    frame++;
                    time_ani = 0;
                }
                if(frame >= tiro_power.Length){frame = 0;}
                GetComponent<SpriteRenderer>().sprite = tiro_power[frame];
                break;
            case Estado.EXPLOTA:
                GetComponent<Rigidbody2D>().linearVelocityX = 0;
                if(frame < explosion.Length){
                    if(time_ani <= cool_frame){
                        time_ani += Time.deltaTime;
                    }else{
                        frame++;
                        time_ani = 0;
                    }
                }else{
                    frame = 0;
                    Destroy(gameObject);
                }
                if(frame >= explosion.Length){
                    GetComponent<SpriteRenderer>().sprite = explosion[explosion.Length-1];
                }else{
                    GetComponent<SpriteRenderer>().sprite = explosion[frame];
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (estado != Estado.EXPLOTA){
            if (collision.gameObject.tag == "Enemigo"){
                collision.SendMessage("restarVida", tipo>1 ? 2 : 1, SendMessageOptions.DontRequireReceiver);
                estado = Estado.EXPLOTA;
            }
        }
    }
}
