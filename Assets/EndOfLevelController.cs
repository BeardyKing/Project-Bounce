using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfLevelController : MonoBehaviour
{
    UI_fade_screen ui_fc;
    UI_Controller ui_c;
    // Start is called before the first frame update
    void Start(){
        ui_fc = GetComponent<UI_fade_screen>();
        ui_c = GetComponent<UI_Controller>();
    }

    // Update is called once per frame
    public bool endOfGame = false;
    void Update(){
        if (StaticData.PlayerHealth <= 0 || endOfGame == true){
            endOfGame = true;
            ui_fc.fade = false;
            if (ui_fc.overlay.GetComponent<Image>().color.a > .9f){
                PlayerPrefs.SetFloat("lastScore", ui_c.timeLasted);
                Debug.Log("SCORE TO BE SENT : " + ui_c.timeLasted);
                SceneManager.LoadScene(3);
            }
        }
    }
}
