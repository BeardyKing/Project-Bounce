using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLinePos : MonoBehaviour
{
    public GameObject[] linePos;
    public LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, linePos[0].transform.position);
        lr.SetPosition(1, linePos[1].transform.position);


    }
}
