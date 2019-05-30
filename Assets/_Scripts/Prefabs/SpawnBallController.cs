using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallController : MonoBehaviour
{
    public GameObject ball;
    public GameObject spawnPoint;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        StaticData.ActiveSpawnPrefabs += 1;

        //GameObject temp = Instantiate(ball);
        //temp.transform.position = spawnPoint.transform.position;
        dir = spawnPoint.transform.position - transform.position;
        dir = new Vector3(dir.x, dir.y, 0);
        dir = dir.normalized;
        //temp.gameObject.GetComponent<MoveInDirection>().SetDirection(dir);
        //temp.gameObject.layer = 12;

        dir = new Vector3(0, Mathf.Abs(dir.y), 0);
        dir = dir.normalized;

        transform.Translate(dir * 15);
    }

    public Vector3 dir;


    private void Awake(){
        
    }

    void SpawnPrefab(){
        GameObject temp = Instantiate(ball);
        temp.transform.position = spawnPoint.transform.position;
        dir = spawnPoint.transform.position - transform.position;
        dir = new Vector3(dir.x, dir.y, 0);
        dir = dir.normalized;
        temp.gameObject.GetComponent<MoveInDirection>().SetDirection(dir);
        temp.gameObject.layer = 12;

        dir = new Vector3(0, Mathf.Abs(dir.y), 0);
        dir = dir.normalized;
        hasSpawnedBall = true;
        StaticData.ActiveSpawnPrefabs -= 1;

    }

    // Update is called once per frame
    Vector3 startPos;
    float timer = 2f;
    float countDown;
    float speed = 3.5f;

    void Update(){
        if (hasSpawnedBall == false) {
            transform.position = Vector3.Lerp(transform.position, startPos, timer * Time.deltaTime);
            countDown += Time.deltaTime;
            if (countDown > timer + (timer / 2)) {
                SpawnPrefab();
            }
        }
        if (hasSpawnedBall == true) {
            transform.Translate(dir * Time.deltaTime * speed);
        }
    }


    public bool hasSpawnedBall = false;

}
