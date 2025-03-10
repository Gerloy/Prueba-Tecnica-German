using Unity.VisualScripting;
using UnityEngine;

public class Spawner_PowerUp : MonoBehaviour
{
    [SerializeField] private float cooldown;
    private float time;
    [SerializeField] private GameObject powerup_prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
        cooldown = UnityEngine.Random.Range(4,10);
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= cooldown){
            GameObject powerup = Instantiate(powerup_prefab);
            powerup.transform.position = transform.position;
            cooldown = UnityEngine.Random.Range(.25f,3);
            time = 0;
        }else{time+=Time.deltaTime;}
    }
}
