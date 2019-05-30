using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class IntroToLevel : MonoBehaviour
{
    public bool startLevel;
    float introCountDown = 3;
    public TextMesh txt_count;
    float fadeoutTimer = 1f;
    public bool isGameLevel;
    // Start is called before the first frame update
    void Start(){
        if (isGameLevel == true) {
            startLevel = false;
        }
        else {
            startLevel = true;
        }
    }

    // Update is called once per frame
    void Update(){
        if (isGameLevel == true) {
            if (introCountDown <= 0) {
                fadeoutTimer -= Time.deltaTime;
                txt_count.fontSize = 170;
                txt_count.text = "PROTECT!";
                txt_count.color = new Color(1, 1, 1, fadeoutTimer);
                if (fadeoutTimer <= .5f) {
                    startLevel = true;
                }
            }
            else {
                txt_count.fontSize = Mathf.RoundToInt(introCountDown % 1 * 250);
                introCountDown -= Time.deltaTime;
                txt_count.text = Mathf.Ceil(introCountDown).ToString();
                txt_count.color = new Color(1, 1, 1, introCountDown % 1);
            }
        }
    }
}
