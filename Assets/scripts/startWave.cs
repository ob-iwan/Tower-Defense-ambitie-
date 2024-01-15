using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startWave : MonoBehaviour
{
    public enemySpawner spawnerScript;

    public void startGame()
    {
        // if clicked on start next wave button activate timer
        spawnerScript.timerActive = true;
    }
}
