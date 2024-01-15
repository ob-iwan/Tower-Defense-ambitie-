using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class towerNormal : MonoBehaviour
{
    public GameObject bulletPrefab;

    public CircleCollider2D circleCollider;

    private Collider2D enemy;

    public float shootSpeed;
    public float shotOffsetY;
    public float bulletLifetime;
    public float range;
    public float bulletSpeed;

    private enemy1 enemyScript;

    private float timer = 1f;

    private bool scriptGotten = false;

    // the first enemy that moves in this collider
    // get its script and dont get any other scripts
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1") && !scriptGotten)
        {
            enemy = collision;
            enemyScript = collision.GetComponent<enemy1>();
            scriptGotten = true;
        }
    }

    // if enemy that is targeted leaves collider set scriptgotten to false
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemy = collision)
        {
            scriptGotten = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        circleCollider.radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        // if tower has a script
        // if enemy is not dead
        // if enemy is in range
        // if timer has counted above the shootspeed
        //
        // reset timer, spawn bullet
        // get direction to enemy and change y coordinate a bit
        // add velocity
        // destroy bullet after lifetime ended
        if (timer < shootSpeed) 
        {
            timer += Time.deltaTime;
        }
        if (scriptGotten)
        {
            if (!enemyScript.ded)
            {
                if (Vector3.Distance(transform.position, enemyScript.transform.position) <= range)
                {
                    if (timer >= shootSpeed)
                    {
                        timer = 0f;
                        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
                        Vector3 directionToEnemy = (enemyScript.transform.position + 
                                                    new Vector3(0, shotOffsetY + UnityEngine.Random.Range(-0.7f, 1f), 0) - 
                                                    transform.position).normalized;
                        bullet.GetComponent<Rigidbody2D>().velocity = directionToEnemy * bulletSpeed;
                        Destroy(bullet, bulletLifetime);
                    }
                }
            }
        }
        // if enemy dies set scriptgotten to false
        if (scriptGotten && enemyScript.ded)
        {
            scriptGotten = false;
        }
    }
}
