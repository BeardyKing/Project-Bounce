using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UI__Score_handler : MonoBehaviour
{
    UI_fade_screen UI_fs;
    public UI_Play_handler UI_ph;
    public int levelSelection;

    bool levelSelectionTimer;
    public bool anim;
    public bool canBeHit = true;
    float lvl_Timer = 1;

    [Space(15)]

    public GameObject[] UI_Text;
    public Color startCol;
    public Color endCol;


    // Start is called before the first frame update
    void Start()
    {
        UI_fs = FindObjectOfType<UI_fade_screen>();
        //UI_ph = FindObjectOfType<UI_Play_handler>();
        startPos = UI_Text[0].transform.localPosition.y;
        //Debug.Log(startPos);
    }

    // Update is called once per frame
    float temp;
    float time;
    float startPos;
    void Update()
    {
        if (levelSelectionTimer) {
            UI_fs.fade = false;
            lvl_Timer -= Time.deltaTime;
            Debug.Log(UI_fs.overlay.GetComponent<Image>().color.a);
            if (UI_fs.overlay.GetComponent<Image>().color.a >= .95f) {
                SceneManager.LoadScene(levelSelection);
            }
        }
        if (anim == true) {

            time += (Time.deltaTime);
            //Debug.Log(time);
            temp = EasingFunction.EaseOutElastic(startPos, .6f, time);
            UI_Text[0].transform.localPosition = new Vector3(UI_Text[0].transform.localPosition.x, temp, UI_Text[0].transform.localPosition.z);
            transform.localPosition = new Vector3(transform.localPosition.x, 3.6f, transform.localPosition.z);

            for (int i = 1; i < 4; i++) {
                UI_Text[i].GetComponent<TextMesh>().color = Vector4.Lerp(UI_Text[i].GetComponent<TextMesh>().color, endCol, 3 * Time.deltaTime);
            }
        }
        if (time > 1) {
            levelSelectionTimer = true;
        }
    }


    private void OnCollisionEnter(Collision other){
        if (other.gameObject.layer == 8) {
            if (canBeHit == true) {
                UI_ph.canBeHit = false;
                anim = true;
            }
        }
    }
}
