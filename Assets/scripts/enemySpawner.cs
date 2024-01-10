using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private float timer;
    public float timerLength;
    public GameObject enemyPrefab;



    // Start is called before the first frame update
    void Start()
    {
        timer += 4;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerLength)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            timer = 0;
            timer += Random.Range(0f, 4f);
        }
    }
}
