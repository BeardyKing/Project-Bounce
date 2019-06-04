using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticData.ActiveBalls = 0;
        StaticData.ActiveLines = 0;
        StaticData.ActiveSpawnPrefabs = 0;
        StaticData.Difficulty = 0;
        StaticData.PlayerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
