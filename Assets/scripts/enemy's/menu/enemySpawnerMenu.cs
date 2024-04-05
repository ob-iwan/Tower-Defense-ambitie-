using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerMenu : MonoBehaviour
{
    private float timer;
    public float timerLength;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if start next wave button is not pressed the timer wont count
        timer += Time.deltaTime;

        if (timer >= timerLength)
        {
            // every time the timer reaches the chosen time
            // spawn an enemy at random height and reset timer
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            timer = 0;
            timer += Random.Range(0f, 1.8f);
        }
    }
}
