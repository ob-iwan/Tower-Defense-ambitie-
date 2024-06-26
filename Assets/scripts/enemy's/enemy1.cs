using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy1 : MonoBehaviour
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
    public bool walking = true;

    private void Awake()
    {
        // get spawner script for its position
        // get shopscript to add loot
        spawnerScript = GameObject.FindGameObjectWithTag("spawner").GetComponent<enemySpawner>();
        shopScript = GameObject.FindGameObjectWithTag("generalSystems").GetComponent<shopSystem>();

        X = spawnerScript.transform.position.x;
        Y = spawnerScript.transform.position.y + Random.Range(-6f, 2f);
        Z = Y + 10f;
        transform.position = new Vector3(X, Y, Z);

        health *= spawnerScript.exponential;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move enemy
        if (walking)
        {
            transform.position = new Vector3(X, Y, Z);
            X += speed * Time.deltaTime;
        }

        if (health <= 0)
        {
            // if enemy dies add loot and destroy gamebject
            shopScript.inPocketMeat += Random.Range(5, 12);
            shopScript.inPocketWood += Random.Range(8, 19);
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
        if (collision.gameObject.CompareTag("wall"))
        {
            walking = false;
        }
        else
        {
            walking = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            walking = false;
        }
        else
        {
            walking = true;
        }
    }
}
