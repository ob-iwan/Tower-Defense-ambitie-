using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float timer;
    public float timerInGameTime;
    public float timer2;
    public float timer3;
    public float timer4;
    public float timer5;
    public float timer6;
    public float timerLength;
    public float timerLength2;
    public float timerSpeeder = 1;
    public float timerSpeeder2 = 1;
    public float exponential = 1;
    public float exponential2 = 1;
    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerInGameTime += Time.deltaTime;

        // if start next wave button is not pressed the timer wont count
        if (timerInGameTime >= 10)
        {
            timer += timerSpeeder * Time.deltaTime;
            timer2 += (timerSpeeder / 2) * Time.deltaTime;
        }
        if (timerInGameTime >= 60)
        {
            timer5 += Time.deltaTime;
        }
        if (timerInGameTime >= 150)
        {
            timer3 += timerSpeeder2 * Time.deltaTime;
            timer4 += (timerSpeeder2 / 2) * Time.deltaTime;
        }
        if (timerInGameTime >= 210)
        {
            timer6 += Time.deltaTime;
        }

        if (timer >= timerLength)
        {
            // every time the timer reaches the chosen time
            // spawn an enemy at random height and reset timer
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            timer = 0;
            timer += Random.Range(0f, 4f);
        }

        if (timer2 >= 15)
        {
            timerSpeeder += 0.1f;
            timer2 = 0;
        }

        if (timer3 >= timerLength2)
        {
            GameObject enemy = Instantiate(enemy2Prefab, transform.position, Quaternion.identity);
            timer3 = 0;
            timer3 += Random.Range(0f, 8f);
        }

        if (timer4 >= 40)
        {
            timerSpeeder2 += 0.2f;
            timer4 = 0;
        }

        if (timer5 >= 20)
        {
            exponential += 0.08f;
            timer5 = 0;
        }

        if (timer6 >= 20)
        {
            exponential2 += 0.16f;
            timer6 = 0;
        }
    }
}
