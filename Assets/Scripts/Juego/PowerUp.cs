using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private Sprite[] ani;
    [SerializeField] private float velx;
    private float time_ani;
    [SerializeField] private float cool_frame;
    private int frame;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frame = 0;
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

        //Movimiento
        Vector3 pos = transform.position;
        pos = new Vector3(pos.x+velx*Time.deltaTime,pos.y,pos.z);
        transform.position = pos;

    }
}
