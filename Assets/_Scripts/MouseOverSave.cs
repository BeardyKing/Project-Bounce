using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverSave : MonoBehaviour
{
    public Vector2[] positions;
    [SerializeField]
    float waitInterval = 8;
    float speed = 2f;
    UI_AddPlayerScore ui_btn;
    public GameObject ui_btn_go;

    // Start is called before the first frame update
    void Start(){
        ui_btn = FindObjectOfType<UI_AddPlayerScore>();
    }

    int choice = 0;
    // Update is called once per frame
    void Update(){
        if (ui_btn.canPressButton == true) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit,100f)) {
                if (hit.collider.tag == "save") {
                    choice = 0;
                }
                else {
                    choice = 1;
                }
            }
        }
        else{
            choice = 0;
        }
        transform.position = Vector3.Lerp(transform.position, positions[choice], speed * Time.deltaTime);
    }
}
