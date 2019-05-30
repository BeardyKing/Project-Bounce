using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public GameObject prefab;
    public int allowedAmountOfLines;

    Vector3[] lineOne = new Vector3[2];
    [SerializeField]
    GameObject[] nodeOne = new GameObject[2];

    public GameObject reflect1;

    public bool mDown = false;
    private Camera cam;
    // Start is called before the first frame update
    void Start(){
        StaticData.ActiveBalls = 0;
        cam = Camera.main;
        lineOne[1] = Vector3.zero;
    }

    // Update is called once per frame
    void Update(){
        MouseController();
        if (mDown == true) {
            if (lineOne[1] == Vector3.zero) {
                Debug.Log("CREATE NODE");
                nodeOne[1] = new GameObject();
                nodeOne[1].name = "node (1)";
                nodeOne[1].transform.localScale = new Vector3(.1f, .1f, .1f);
            }
            Vector3 screen = cam.ScreenToWorldPoint(Input.mousePosition);
            lineOne[1] = new Vector3(screen.x, screen.y, 0.5f);
        }

        //Debug.Log("LINES ACTIVE : " + StaticData.ActiveLines);
    }

    void MouseController() {
        if (Input.GetMouseButtonDown(0)) {
            if (StaticData.ActiveLines < allowedAmountOfLines) {
               reflect1 = Instantiate(prefab);
               reflect1.gameObject.layer = 10;
               Destroy(nodeOne[0]);
                
                mDown = true;
                nodeOne[0] = new GameObject();
                nodeOne[0].name = "node (0)";

                nodeOne[0].transform.localScale = new Vector3(.1f, .1f, .1f);

                Vector3 screen = cam.ScreenToWorldPoint(Input.mousePosition);
                lineOne[0] = new Vector3(screen.x, screen.y, 0.5f);

                nodeOne[0].transform.position = lineOne[0];
                lineOne[1] = new Vector3(screen.x, screen.y, 0.5f);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            if (StaticData.ActiveLines <= allowedAmountOfLines) {
                mDown = false;
                if (reflect1) {
                    reflect1.gameObject.layer = 8;
                }
                    reflect1 = null;
            }
        }
        if (mDown == true) {
            SpawnReflect(lineOne[0], lineOne[1]);

        }
    }


    float reflect_width = .1f;

    void SpawnReflect(Vector3 startPos, Vector3 endPos)
    {
        try {
            reflect1.transform.position = (lineOne[0] + lineOne[1]) * 0.5f;
            reflect1.transform.eulerAngles = new Vector3(0, 0, AngleBetweenPoints(lineOne[0], lineOne[1]));
            Vector3 dist = lineOne[0] - lineOne[1];
            reflect1.transform.localScale = new Vector3(dist.magnitude, reflect_width, reflect_width);

        }
        catch (System.Exception) {
            Debug.LogWarning("ERR @ SPAWN REFLECT | PROBABLY ISSUE : reflect1 was not destroyed");
            throw;
        }
    }

    float AngleBetweenPoints(Vector3 B, Vector3 A){
        float angle = Mathf.Atan2(A.y - B.y, A.x - B.x) * 180 / Mathf.PI;
        return angle;
    }
}
