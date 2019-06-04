using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfNodesEnabled : MonoBehaviour
{
    public GameObject[] NodeRef;
    public int AmountOfNodes;
    public int AmountOfActiveNodes;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        AmountOfActiveNodes = 0;
        for (int i = 0; i < NodeRef.Length; i++) {
            if (NodeRef[i].GetComponent<CheckCollisionTypeWithWalls>().isEnabled == false) {
                AmountOfActiveNodes++;
            }
        }
        
        if (AmountOfActiveNodes < AmountOfNodes / 4) {
            if (gameObject.layer == 8) {
                Destroy(gameObject);
                StaticData.ActiveLines -= 1;

            }
        }
    }
}
