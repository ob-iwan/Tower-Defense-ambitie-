using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    private enemySpawner spawnerScript;
    private shopSystem shopScript;
    public ParticleSystem blood;
    public GameObject child;

    public float health;

    public float speed;

    private float X;
    private float Y;
    private float Z;

    public bool ded = false;

    private void Awake()
    {
        // get spawner script for its position
        // get shopscript to add loot
        spawnerScript = GameObject.FindGameObjectWithTag("spawner").GetComponent<enemySpawner>();
        shopScript = GameObject.FindGameObjectWithTag("generalSystems").GetComponent<shopSystem>();

        X = spawnerScript.transform.position.x;
        Y = spawnerScript.transform.position.y + Random.Range(-6f, 2f);
        Z = spawnerScript.transform.position.z;
        transform.position = new Vector3(X, Y, Z);

        health *= spawnerScript.exponential2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move enemy
        transform.position = new Vector3(X, Y, Z);
        X += speed * Time.deltaTime;

        if (health <= 0)
        {
            // if enemy dies add loot and destroy gamebject
            shopScript.inPocketMeat += Random.Range(14, 24);
            shopScript.inPocketWood += Random.Range(17, 33);
            child.gameObject.transform.parent = null;
            blood.Play();
            Destroy(this.gameObject);
            ded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if enemy hit by bullet decrease life by one and destroy bullet object
        if (collision.gameObject.CompareTag("bullet1"))
        {
            health--;
            Destroy(collision.gameObject);
        }
    }
}
