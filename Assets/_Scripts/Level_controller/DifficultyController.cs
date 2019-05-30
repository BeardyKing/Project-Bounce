using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public TextMesh text_Debug;
    LevelController lc;
    // Start is called before the first frame update
    void Start(){
        lc = FindObjectOfType<LevelController>();
        timeSpentOnCurrentLevel = maxTimeToSpendOnLevel + lc.timeToShift;
    }

    // Update is called once per frame
    void Update() {
        DebugCont();
        timeSpentOnCurrentLevel -= Time.deltaTime;
        if (timeSpentOnCurrentLevel <= 0) {
            ChangeLevel();
            timeSpentOnCurrentLevel = maxTimeToSpendOnLevel + lc.timeToShift;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.LogWarning("SET HP TO 0");
            StaticData.PlayerHealth = 0;
        }
    }

    void SelectLevelToLerpTo(){

    }

    void DebugCont(){
        DebugChangeDifficulty();
        DebugText();
    }

    void DebugText(){
        text_Debug.text = "Diff : " + StaticData.Difficulty.ToString() + "  / TIME ON LVL : " + timeSpentOnCurrentLevel.ToString();
    }

    void DebugChangeDifficulty(){
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            ChangeLevel();
        }
    }



    float timeSpentOnCurrentLevel;
    [Range(2,30)]
    public float maxTimeToSpendOnLevel = 15f;

    float chanceToOpenExit = 50;
    bool openBallExits;


    void ChangeLevel(){
        float checkAgainst;
        checkAgainst = Random.Range(35f,100f);
        
        if (checkAgainst >= chanceToOpenExit) {
            StaticData.Difficulty += 2;
        }
        else {
            StaticData.Difficulty += 1;
        }
        lc.ResetTimer();
        lc.mesh_1 = lc.mesh_2;
        if (StaticData.Difficulty < FindObjectOfType<LevelController>().amountOfMeshes) {
            lc.mesh_2 = StaticData.Difficulty;
        }
        else {
            lc.mesh_2 = (int)Random.Range(0, FindObjectOfType<LevelController>().amountOfMeshes);
        }
    }
}
