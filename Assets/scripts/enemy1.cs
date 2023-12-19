using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    private GameObject enemyPrefab;
    public int health;
    public int damage;

    public float speed;

    public bool ded = false;

    private void Awake()
    {
        enemyPrefab = GameObject.Find("enemy1");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            enemyPrefab.SetActive(false);
            ded = true;
        }
    }
}
