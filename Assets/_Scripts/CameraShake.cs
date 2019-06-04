using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour{
    float magnitude = 0f;
    float decrement;
    Vector3 startPos;

    void Start(){
        startPos = transform.position;
    }

    void Update(){
        if (magnitude > 0) {
            transform.position = startPos + Random.insideUnitSphere * magnitude;
            magnitude -= Time.deltaTime * decrement;
            decrement -= Time.deltaTime * magnitude;
        }
        else {
            magnitude = 0f;
            transform.position = startPos;
        }
    }

    public void EvokeShake(float inDecrement , float inMag){ // .11 // .02
        magnitude = inMag;
        decrement = inDecrement;
    }
}
