using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour{
    public UI_Play_handler ui_play;
    public UI__Score_handler ui_score;
    private void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ball") {
            if (ui_play.anim == false && ui_score.anim == false) {
                Application.Quit();
            }
        }
    }
}
