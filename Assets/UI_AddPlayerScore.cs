using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UI_AddPlayerScore : MonoBehaviour
{
    float recievedValue;
    public GameObject textArea;
    public string playerName;
    public UI_score_controller ui_sc;

    public GameObject saveIcon;

    public GameObject[] text;

    public GameObject btn_text;
    public Button[] inputButtons;
    // Start is called before the first frame update
    void Start(){
        ui_sc = FindObjectOfType<UI_score_controller>();
        recievedValue = PlayerPrefs.GetFloat("lastScore");
        textArea.GetComponent<TextMesh>().text = recievedValue.ToString("F");
        if (PlayerPrefs.GetString("t1") != ""){
            text[0].GetComponent<TextMesh>().text = PlayerPrefs.GetString("t1");
            text[1].GetComponent<TextMesh>().text = PlayerPrefs.GetString("t2");
            text[2].GetComponent<TextMesh>().text = PlayerPrefs.GetString("t3");
            text[3].GetComponent<TextMesh>().text = PlayerPrefs.GetString("t4");
        }
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log("VAL : " + recievedValue);
        playerName =    text[0].GetComponent<TextMesh>().text +
                        text[1].GetComponent<TextMesh>().text +
                        text[2].GetComponent<TextMesh>().text +
                        text[3].GetComponent<TextMesh>().text;

        if (canPressButton == false){
            saveIcon.GetComponent<SpriteRenderer>().color = Vector4.Lerp(saveIcon.GetComponent<SpriteRenderer>().color, Vector4.one, 1 * Time.deltaTime);
            if (OnePass == true){
                OnePass = false;
                GetComponent<Button>().interactable = false;
                btn_text.GetComponent<TextMesh>().text = "SAVED";
                for (int i = 0; i < inputButtons.Length; i++){
                    inputButtons[i].interactable = false;
                }
            }
        }
    }

    bool OnePass = true;

    public void OnButonSelected(){
        if (canPressButton == true)
        {
            playerName =    text[0].GetComponent<TextMesh>().text +
                            text[1].GetComponent<TextMesh>().text +
                            text[2].GetComponent<TextMesh>().text +
                            text[3].GetComponent<TextMesh>().text;

            PlayerPrefs.SetString("t1", text[0].GetComponent<TextMesh>().text);
            PlayerPrefs.SetString("t2", text[1].GetComponent<TextMesh>().text);
            PlayerPrefs.SetString("t3", text[2].GetComponent<TextMesh>().text);
            PlayerPrefs.SetString("t4", text[3].GetComponent<TextMesh>().text);


            ui_sc.AddValueToPlayerPrefs(playerName, recievedValue);
            Debug.Log("BUTTON PRESSED");
            canPressButton = false;
        }
    }

    public bool canPressButton = true;
}
