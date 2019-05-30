using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 dir;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 8) {
            if (other.gameObject.tag == "Ball") {
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.gameObject.GetComponent<MoveInDirection>().Direction = dir;
                other.gameObject.layer = 10;
                Destroy(other.gameObject, .5f);
                StaticData.ActiveBalls -= 1;
                if (dir == Vector3.zero) {
                    Debug.LogWarning("DESTROYED BALL OUT OF BOUNDS");
                }
                FindObjectOfType<ExtraLifeController>().spawnHealthCounter -= Random.Range(4, 8);
                FindObjectOfType<SpawnPushBall_Manager>().timeWithoutBall += 10f;
            }
        }
    }
}
