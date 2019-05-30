using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData{
    private static int activeLines = 0;
    private static int activeBalls = 0;
    private static int difficulty = 0;
    private static int activeSpawnPrefabs;



    private static int playerHealth = 3;

    public static int ActiveSpawnPrefabs
    {
        get {
            return activeSpawnPrefabs;
        }
        set {
            activeSpawnPrefabs = value;
        }
    }


    public static int ActiveBalls{
        get {
            return activeBalls;
        }
        set {
            activeBalls = value;
        }
    }

    public static int Difficulty{
        get {
            return difficulty;
        }
        set {
            difficulty = value;
        }
    }

    public static int ActiveLines{
        get {
            return activeLines;
        }
        set {
            if (activeLines < 0) {
                activeLines = 0;
            }
            else {
                activeLines = value;
            }
        }
    }

    public static int PlayerHealth{
        get {
            return playerHealth;
        }
        set {
            playerHealth = value;
        }
    }
}
