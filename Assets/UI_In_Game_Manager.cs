using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_In_Game_Manager : MonoBehaviour
{
    public GameObject[] UI_Obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Color col_1_Target;
    Color col_2_Target;
    // Update is called once per frame
    void Update(){
        if (StaticData.ActiveLines == 0) {
            col_1_Target = new Color(10, 10, 10, 10);
            col_2_Target = new Color(10, 10, 10, 10);

        }
        if (StaticData.ActiveLines == 1) {
            col_1_Target = new Color(10, 10, 10, 10);
            col_2_Target = new Color(0, 0, 0, 0);
        }
        if (StaticData.ActiveLines == 2) {
            col_1_Target = new Color(0, 0, 0, 0);
            col_2_Target = new Color(0, 0, 0, 0);
        }
        //UI_Obj[0].GetComponent<Renderer>().material.color = col_1_Target;
        //UI_Obj[1].GetComponent<Renderer>().material.color = col_2_Target;
        UI_Obj[0].GetComponent<Renderer>().material.color = Vector4.Lerp(UI_Obj[0].GetComponent<Renderer>().material.color, col_1_Target, 3f * Time.deltaTime);
        UI_Obj[1].GetComponent<Renderer>().material.color = Vector4.Lerp(UI_Obj[1].GetComponent<Renderer>().material.color, col_2_Target, 3f * Time.deltaTime);


    }
}
