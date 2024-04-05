using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theWall : MonoBehaviour
{
    public int health = 20;

    public float timer;
    private int exponential = 0;

    public bool scriptGotten = false;

    private Collider2D enemy;
    private enemy1 enemyScript;


    public GameObject wallPrefab;
    public theWall script;
    private shopSystem shop;

    private void Awake()
    {
        shop = GameObject.FindGameObjectWithTag("generalSystems").GetComponent<shopSystem>();
    }

    void Update()
    {
        if (enemy != null)
        {
            timer += 1 * exponential * Time.deltaTime;
        }
        if (timer >= 3)
        {
            health--;
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1") && !scriptGotten)
        {
            exponential++;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1") && !scriptGotten)
        {
            enemy = collision;
            enemyScript = collision.GetComponent<enemy1>();
            scriptGotten = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemy == collision)
        {
            enemy = null;
            enemyScript = null;
            scriptGotten = false;
            exponential--;
        }
    }

    public void upgrade()
    {
        if (shop.inPocketCoins >= 50 && shop.inPocketWood >= 50)
        {
            Destroy(gameObject);
            GameObject newWall = Instantiate(wallPrefab, transform.position, Quaternion.identity);
            shop.inPocketCoins -= 50;
            shop.inPocketWood -= 50;
        }
    }
}
