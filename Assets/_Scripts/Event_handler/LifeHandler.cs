using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    GameObject plane;
    // Start is called before the first frame update
    void Start(){
        plane = FindObjectOfType<ClippingPlane>().gameObject;
    }
    float targetZ;
    // Update is called once per frame
    void Update(){
        if (StaticData.PlayerHealth == 3) {
            targetZ = 1f;
        }
        if (StaticData.PlayerHealth == 2) {
            targetZ = 0.33f;

        }
        if (StaticData.PlayerHealth == 1) {
            targetZ = -0.33f;
        }
        if (StaticData.PlayerHealth == 0) {
            targetZ = -1.2f;
        }
        //plane.transform.localPosition = new Vector3(0, 0, targetZ);
        plane.transform.localPosition = Vector3.Lerp(plane.transform.localPosition, new Vector3(0, 0, targetZ), 2f * Time.deltaTime);
    }
}
