using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterX : MonoBehaviour
{
    public float timeAlive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (gameObject.layer == 8) {
            //timeAlive -= Time.deltaTime;
            //if (timeAlive <= 0) {
            //    Destroy(gameObject);
            //    StaticData.ActiveLines -= 1;
            //}
        }
    }
    void OnCollisionStay(Collision other){
        if (true) {

        }
    }
}
