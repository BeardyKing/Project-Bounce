using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionTypeWithWalls : MonoBehaviour
{
    public AmountOfNodesEnabled nodes;
    public GameObject parent;
    // Start is called before the first frame update
    void Start(){
        //GetComponent<Renderer>().material.color = new Color(1, 0.333f, 0.8941f, 5);
        nodes.AmountOfNodes++;
    }

    // Update is called once per frame
    float rot;
    Color targetCol;
    void FixedUpdate()
    {
        //if (isEnabled == true) {
        //    counter -= Time.deltaTime;
        //    if (counter <= 0) {
        //        counter = 0.5f;
        //        ColOn = !ColOn;
        //    }
        //    if (ColOn == true) {
        //        targetCol = new Color(10, 10, 10, 10);
        //    }
        //    else {
        //        targetCol = new Color(1,0.333f,0.8941f,5);
        //    }
        //    GetComponent<Renderer>().material.color = Vector4.Lerp(GetComponent<Renderer>().material.color, targetCol, .2f * Time.deltaTime);
        //}
        //else {
        //    GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

        //}
        //rot++;
        //transform.eulerAngles = parent.transform.eulerAngles;
        ExitCol();
    }

    private void Update(){
        
    }

    float counter = 0.5f;
    bool ColOn;


    public bool isEnabled = false;

    void OnTriggerStay(Collider other){
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "outOfBounds") {
            StayCol();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "outOfBounds") {
            ExitCol();
        }
    }

    void ExitCol(){
        isEnabled = false;
        //GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
    }

    void StayCol(){
        //GetComponent<Renderer>().material.color = Color.black;
        isEnabled = true;
    }



}
