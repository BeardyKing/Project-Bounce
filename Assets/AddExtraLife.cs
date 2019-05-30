using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddExtraLife : MonoBehaviour
{

    float timeAlive;

    // Start is called before the first frame update
    void Start()
    {

        timeAlive = Random.Range(9, 15);
        
    }

    // Update is called once per frame

    void Update()
    {
        timeAlive -= Time.deltaTime;
        if (timeAlive < 0){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("LAYER : " + other.gameObject.layer);
        Debug.Log("TAG : " + other.gameObject.tag);
        if (other.gameObject.tag == "Ball") {
            if (other.gameObject.layer == 8 || other.gameObject.layer == 12)
            {
                Debug.Log("ADD HEALTH TO STATIC DATA");
                Destroy(gameObject);
                if (StaticData.PlayerHealth < 3){
                    StaticData.PlayerHealth += 1;
                }
                else if (StaticData.PlayerHealth >= 3){
                    FindObjectOfType<healthController>().canBeHit = false;
                    FindObjectOfType<healthController>().countDown = 7f;
                }
            }
        }
    }
}
