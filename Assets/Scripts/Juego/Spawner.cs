using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemigo Debil")]
    [SerializeField]private Sprite[] ani_debil;
    [SerializeField]private int puntos_debil;
    [SerializeField]private int vida_debil;

    [Header("Enemigo Intermedio")]
    [SerializeField]private Sprite[] ani_medio;
    [SerializeField]private int puntos_medio;
    [SerializeField]private int vida_medio;

    [Header("Enemigo Fuerte")]
    [SerializeField]private Sprite[] ani_fuerte;
    [SerializeField]private int puntos_fuerte;
    [SerializeField]private int vida_fuerte;

    [Header("General")]
    [SerializeField]private float cooldown_enes;
    [SerializeField]private float time;
    [SerializeField]private GameObject ene_prefav;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
        cooldown_enes = UnityEngine.Random.Range(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= cooldown_enes){
            GameObject enemigo = Instantiate(ene_prefav);
            int tipo = (int) Math.Floor(UnityEngine.Random.Range(0,2.9f));
            Enemigo script = enemigo.GetComponent<Enemigo>();
            switch(tipo){
                case 0:
                    script.ani = ani_debil;
                    script.puntos = puntos_debil;
                    script.vida = vida_debil;
                    break;
                case 1:
                    script.ani = ani_medio;
                    script.puntos = puntos_medio;
                    script.vida = vida_medio;
                    break;
                case 2:
                    script.ani = ani_fuerte;
                    script.puntos = puntos_fuerte;
                    script.vida = vida_fuerte;
                    break;
            }
            enemigo.transform.position = transform.position;
            cooldown_enes = UnityEngine.Random.Range(.25f,3);
            time = 0;
        }else{time+=Time.deltaTime;}
    }
}
