using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Game State SO")]
public class GameStateSO : ScriptableObject
{
    public float survivalTimer;
    public float difficultyScaling;
    public int score;
    public int highScore;

    public int tutorialStep;
    public bool tutorialComplete;
    public int shotsLanded;
    public int slimesKilled;

    public bool isPlayerAlive;

    public bool currentRound;
    public bool roundTimer;
    public bool roundCompleted;
}
