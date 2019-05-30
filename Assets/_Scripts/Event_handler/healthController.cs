using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
    public bool canBeHit = true;

    public float countDown;
    [Range(0,3f)]
    public float startTimer;

    void Start(){
        rend = GetComponent<Renderer>();
        countDown = startTimer;
    }
    Color currentCol;
    public Color col1;
    public Color col2;
    public Renderer rend;
    // Update is called once per frame
    void Update(){
        if (canBeHit == false) {
            Wait();
            currentCol = Vector4.Lerp(currentCol, col2, 6f * Time.deltaTime);
        }
        if (canBeHit == true) {
            currentCol = Vector4.Lerp(currentCol, col1, 6f * Time.deltaTime);
        }
        rend.material.SetColor("_WireColor", currentCol);
        rend.material.SetColor("_BaseColor", currentCol);
    }

    void Wait(){
        countDown -= Time.deltaTime;
        if (countDown < 0) {
            canBeHit = true;
            countDown = startTimer;
        }
    }

    private void OnCollisionEnter(Collision other){
        if (canBeHit == true) {
            if (other.gameObject.layer == 8) {
                canBeHit = false;
                StaticData.PlayerHealth -= 1;
            }
        }
    }
}
