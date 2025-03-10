using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public Sprite[] ani;
    public int puntos;
    public int vida;
    public float velx;

    private float vely;
    [SerializeField] private float cool_vel;
    private float time_vel;

    private float time_ani;
    [SerializeField] private float cool_frame;
    private int frame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frame = 0;
        velx = Random.Range(-20,-500);
        time_ani = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Animaciones
        if(time_ani > cool_frame){
            time_ani += Time.deltaTime;
        }else{
            frame++;
            time_ani = 0;
        }
        if(frame >= ani.Length){frame = 0;}
        GetComponent<SpriteRenderer>().sprite = ani[frame];

        //Velocidad en y para que varie un poquito
        if (time_vel > cool_vel){
            vely = Random.Range(-400,400);
            time_vel = 0;
        }else{time_vel+=Time.deltaTime;}

        Vector3 pos = transform.position;
        pos = new Vector3(pos.x+velx*Time.deltaTime,pos.y+vely*Time.deltaTime,pos.z);
        transform.position = pos;
    }

    public void restarVida(int damage){
        Debug.Log("Cagado a tiros");
        vida -= damage;
        if (vida <= 0){
            GameObject.Find("Manager").SendMessage("sumarPuntos", puntos);
            Destroy(gameObject);
        }
    }
}
