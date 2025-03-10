using TMPro;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Manager_Juego : MonoBehaviour
{

    [SerializeField]private GameObject t_score_actual;
    [SerializeField]private GameObject t_highscore;
    [SerializeField]private int score_actual;
    [SerializeField]private int highscore;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cargarDatos();
        score_actual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score_actual >= highscore){highscore = score_actual;}

        t_score_actual.GetComponent<TextMeshProUGUI>().text = score_actual.ToString();
        t_highscore.GetComponent<TextMeshProUGUI>().text = highscore.ToString();
    }

    public void perder(){
        guardarDatos();
        SceneManager.LoadScene("Menu");
    }

    public void sumarPuntos(int puntos){
        score_actual += puntos;
    }

    public void guardarDatos(){
        DatosGuardados guardado = new DatosGuardados();
        guardado.highscore = highscore;

        string json_data = JsonUtility.ToJson(guardado);
        string path = Application.persistentDataPath + "/datos_guardados.json";
        File.WriteAllText(path, json_data);
    }

    public void cargarDatos(){
        string path = Application.persistentDataPath + "/datos_guardados.json";
        if(File.Exists(path)){
            string json_data = File.ReadAllText(path);
            DatosGuardados cargado = JsonUtility.FromJson<DatosGuardados>(json_data);

            highscore = cargado.highscore;
        }
        else{highscore = 10000;}
    }
}
