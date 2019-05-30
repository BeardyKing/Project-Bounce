using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_fade_screen : MonoBehaviour
{
    public GameObject overlay;
    public Color startCol;
    Color targetCol;

    public bool fade = true;


    public float speed = 0.5f;
    public float inSpeed = 3f;

    // Start is called before the first frame update
    void Start(){
        overlay.SetActive(true);
        overlay.GetComponent<Image>().color = startCol;
        targetCol = new Vector4(1,1,1,0);
    }

    // Update is called once per frame
    void Update(){
        if (fade == true) {
            if (overlay.GetComponent<Image>().color.a > 0) {
                overlay.GetComponent<Image>().color = Vector4.Lerp(overlay.GetComponent<Image>().color, targetCol, 2 * Time.deltaTime * inSpeed);
                if (overlay.GetComponent<Image>().color.a < .1f) {
                    //Debug.Log("DO THE THING");
                    //overlay.GetComponent<Image>().color = Vector4.zero;
                }
            }
        }
        if (fade == false) {
            if (overlay.GetComponent<Image>().color.a < 1) {
                overlay.GetComponent<Image>().color = Vector4.Lerp(overlay.GetComponent<Image>().color, startCol, 1f * Time.deltaTime * speed);
            }
        }
    }
}
