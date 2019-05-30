﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        StaticData.ActiveLines += 1;
        currentCol = new Vector4(col.r, col.g, col.b, .01f);
    }

    // Update is called once per frame
    void Update(){
        ChangeColour();
    }
    //00BFA9 OG COL

    public Color col;
    Color currentCol;

    float minimumSize = .3f;

    void ChangeColour(){
        Renderer rend = GetComponent<Renderer>();
        if (beingDestroyed == true) {
            currentCol = Vector4.Lerp(currentCol, Vector4.zero, 4f * Time.deltaTime);
        }
        else {
            if (gameObject.layer == 10) {
                currentCol = new Vector4(col.r / 3, col.g / 3, col.b / 3, .1f);
            }
            else if (gameObject.layer == 8) {
                if (currentCol != col) {
                    currentCol = Vector4.Lerp(currentCol, new Vector4(col.r, col.g, col.b, 1), 22f * Time.deltaTime);
                    if (transform.localScale.x < minimumSize) {
                        Destroy(gameObject);
                        StaticData.ActiveLines -= 1;
                        Debug.Log("Object too small to spawn");
                    }
                }
                //currentCol = new Vector4(col.r, col.g, col.b, 1);

            }
        }
            rend.material.SetColor("_WireColor", currentCol);
            rend.material.SetColor("_BaseColor", currentCol);
    }
    bool beingDestroyed = false;
    bool singlePass = false;
    private void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Ball") {
            beingDestroyed = true;
            //gameObject.layer = 10;
            Destroy(gameObject, 0.4f);
            if (beingDestroyed == true) {
                if (singlePass == false) {
                    singlePass = true;
                    StaticData.ActiveLines -= 1;
                }
            }
        }
    }


    float outOfBoundsCounter;

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.tag);

    }
    private void OnCollisionStay(Collision other){
        //Debug.Log(other.gameObject.tag);
        
    }
}