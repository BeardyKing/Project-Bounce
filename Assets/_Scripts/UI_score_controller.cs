using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_score_controller : MonoBehaviour
{
    string pBase = "player";
    string concatScore = "score";
    string concatName = "name";
    int maxScoreAmount = 8;

    public GameObject[] playerName;
    public GameObject[] playerScore;
    public bool getter;

    // Start is called before the first frame update
    void Start(){
        if (PlayerPrefs.HasKey(pBase + concatScore + 0) == false){
            PopulateEmptyPlayerPrefs();
        }
        if (getter){
            GetPlayerPrefVals();  
        }
    }

    // Update is called once per frame
    void Update(){
        if ((Input.GetKey(KeyCode.LeftControl)) && (Input.GetKey(KeyCode.E))){
            PlayerPrefs.DeleteAll();
            Debug.LogWarning("DELETED KEYS");
        }
    }

    void PopulateEmptyPlayerPrefs(){
        for (int i = 0; i < maxScoreAmount; i++){
            PlayerPrefs.SetString(pBase + concatName + i, "USER");
            PlayerPrefs.SetFloat(pBase + concatScore + i, 70 - (i * 10));
        }
    }

    void GetPlayerPrefVals(){
        //for (int i = 0; i < maxScoreAmount; i++){
        //    Debug.Log(PlayerPrefs.GetString(pBase + concatName + i) + " : " + PlayerPrefs.GetFloat(pBase + concatScore + i));
        //}
        if (playerName[0]){
            for (int i = 0; i < maxScoreAmount; i++){
                playerName[i].gameObject.GetComponent<TextMesh>().text  = PlayerPrefs.GetString(pBase + concatName + i);
                playerScore[i].gameObject.GetComponent<TextMesh>().text = PlayerPrefs.GetFloat(pBase + concatScore + i).ToString("F");
            }
        }
    }

    public void AddValueToPlayerPrefs(string name, float score){
        for (int i = 0; i < maxScoreAmount; i++){
            if (score >= PlayerPrefs.GetFloat(pBase + concatScore + i)){
                Debug.Log("BIGGER");
                for (int j = maxScoreAmount; j > i; j--){
                    Debug.Log(j + " count");
                    PlayerPrefs.SetString(pBase + concatName + j, PlayerPrefs.GetString(pBase + concatName + (j - 1)));
                    PlayerPrefs.SetFloat(pBase + concatScore + j, PlayerPrefs.GetFloat(pBase + concatScore + (j - 1)));
                }
                PlayerPrefs.SetString(pBase + concatName + i, name.ToUpper());
                PlayerPrefs.SetFloat(pBase + concatScore + i, score);
                break;
            }
        }
    }
}
