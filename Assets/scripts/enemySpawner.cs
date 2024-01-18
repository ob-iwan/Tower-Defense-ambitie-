using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private float timer;
    public float timerLength;
    public GameObject enemyPrefab;

    public bool timerActive = false;
    public bool loop = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if start next wave button is not pressed the timer wont count
        if (timerActive)
        {
            timer += Time.deltaTime;
        }

        if (timer >= timerLength && loop)
        {
            // every time the timer reaches the chosen time
            // spawn an enemy at random height and reset timer
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            timer = 0;
            timer += Random.Range(0f, 4f);
        }

        if (timer > 3)
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                loop = true;
                timer = -5;
            }
        }
    }

    public void startGame()
    {
        // if clicked on start next wave button activate timer
        timerActive = true;
    }
}
