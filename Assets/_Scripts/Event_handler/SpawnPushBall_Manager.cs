using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPushBall_Manager : MonoBehaviour
{
    public GameObject pushBall;
    IntroToLevel introToLevel;

    [SerializeField] Vector3[] oneBallSpawnPos;
    [SerializeField] Vector3[] oneBallSpawnRot;

    [SerializeField] Vector3[] twoBallSpawnPos;
    [SerializeField] Vector3[] twoBallSpawnRot;

    [SerializeField] Vector3[] threeBallSpawnPos;
    [SerializeField] Vector3[] threeBallSpawnRot;


    // Start is called before the first frame update
    void Start(){
        introToLevel = FindObjectOfType<IntroToLevel>();
    }

    public float timeWithoutBall;

    // Update is called once per frame
    void Update()
    {
        if (introToLevel.startLevel == true) {
            if (timeWithoutBall > 0) {
                timeWithoutBall -= Time.deltaTime;
            }
            if (GetComponent<UI_fade_screen>().overlay.GetComponent<Image>().color.a < .5) {
                if (StaticData.ActiveBalls == 0) {
                    int rndInt;
                    rndInt = Random.Range(0, oneBallSpawnPos.Length);
                    if (StaticData.ActiveSpawnPrefabs == 0) {
                        GameObject temp = Instantiate(pushBall);
                        temp.transform.position = oneBallSpawnPos[rndInt];
                        temp.transform.eulerAngles = oneBallSpawnRot[rndInt];
                        //temp.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                        //temp.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
                    }
                }
                if (StaticData.ActiveBalls == 1) {
                    if (StaticData.ActiveSpawnPrefabs == 0) {
                        if (StaticData.Difficulty > 3) {
                            if (timeWithoutBall <= 0) {
                                GameObject temp = Instantiate(pushBall);
                                temp.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                                temp.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
                            }
                        }
                    }
                }
                if (StaticData.ActiveBalls == 2) {
                    if (StaticData.ActiveSpawnPrefabs == 0) {
                        if (StaticData.Difficulty > 10) {
                            if (timeWithoutBall <= 8f) {
                                GameObject temp = Instantiate(pushBall);
                                temp.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                                temp.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
                            }
                        }
                    }
                }
                if (StaticData.ActiveBalls == 3) {

                }
                if (StaticData.Difficulty < 4) {
                    if (StaticData.PlayerHealth != 3) {

                    }
                }
            }
        }
    }
}
