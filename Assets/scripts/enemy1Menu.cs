using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Menu : MonoBehaviour
{
    private enemySpawnerMenu spawnerScript;
    private shopSystem shopScript;
    public ParticleSystem blood;
    public GameObject child;

    public int health;

    public float speed;

    private float X;
    private float Y;
    private float Z;

    public bool ded = false;

    private void Awake()
    {
        // get spawner script for its position
        // get shopscript to add loot
        spawnerScript = GameObject.FindGameObjectWithTag("spawner").GetComponent<enemySpawnerMenu>();

        X = spawnerScript.transform.position.x;
        Y = spawnerScript.transform.position.y + Random.Range(-6f, 2f);
        Z = spawnerScript.transform.position.z;
        transform.position = new Vector3(X, Y, Z);
    }

    // Update is called once per frame
    void Update()
    {
        // move enemy
        transform.position = new Vector3(X, Y, Z);
        X += speed * Time.deltaTime;

        if (health <= 0)
        {
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
