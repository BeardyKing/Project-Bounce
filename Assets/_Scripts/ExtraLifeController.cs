using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeController : MonoBehaviour
{
    public GameObject health;

    public float spawnHealthCounter;
    // Start is called before the first frame update
    void Start()
    {
        spawnHealthCounter = Random.Range(5, 8);
    }

    // Update is called once per frame
    void Update(){
        if (StaticData.Difficulty > 4 && StaticData.Difficulty < 6){
            spawnHealthCounter -= Time.deltaTime;
            if (spawnHealthCounter < 0)
            {
                spawnHealthCounter = Random.Range(15, 25);
                GameObject temp = Instantiate(health);
                temp.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 0.5f);
                temp.transform.eulerAngles = new Vector3(-90, 0, 0);
            }
        }
        if (StaticData.Difficulty > 8 && StaticData.Difficulty < 12)
        {
            spawnHealthCounter -= Time.deltaTime;
            if (spawnHealthCounter < 0)
            {
                spawnHealthCounter = Random.Range(15, 25);
                GameObject temp = Instantiate(health);
                temp.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 0.5f);
                temp.transform.eulerAngles = new Vector3(-90, 0, 0);

            }
        }
        if (StaticData.Difficulty > 14 && StaticData.Difficulty < 17)
        {
            spawnHealthCounter -= Time.deltaTime;
            if (spawnHealthCounter < 0)
            {
                spawnHealthCounter = Random.Range(8, 16);
                GameObject temp = Instantiate(health);
                temp.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 0.5f);
                temp.transform.eulerAngles = new Vector3(-90, 0, 0);
            }
        }
        if (StaticData.Difficulty > 20 )
        {
            spawnHealthCounter -= Time.deltaTime;
            if (spawnHealthCounter < 0)
            {
                spawnHealthCounter = Random.Range(15, 30);
                GameObject temp = Instantiate(health);
                temp.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 0.5f);
            }
        }
    }
}
