using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour{
    public TextMesh text_Debug_health;
    public TextMesh text_Debug_ActiveBalls;
    void Start(){
        
    }

    public float timeLasted;

    void Update(){

        if (StaticData.PlayerHealth > 0) {
            timeLasted += Time.deltaTime;
        }

        text_Debug_health.text = "Health : " + StaticData.PlayerHealth.ToString();
        text_Debug_ActiveBalls.text = "time lasted : " + timeLasted.ToString();
    }
}
