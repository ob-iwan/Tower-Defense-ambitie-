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
   
    public GameObject button;

    public float shootSpeed;
    public float shotOffsetY;
    public float bulletLifetime;
    public float range;
    public float bulletSpeed;

    public Vector2 buttonPos;

    private enemy1 enemyScript;

    private float timer = 1f;

    private bool scriptGotten = false;
    public bool lastTower = false;

    // Start is called before the first frame update
    void Start()
    {
        // sets the towerUpgrade button to the right position
        buttonPos = transform.position + new Vector3(0, 0.65f, 0);
        circleCollider.radius = range;
        button.transform.position = buttonPos;
    }

    // Update is called once per frame
    void Update()
    {
        // if tower has a script
        // enemy is not dead
        // enemy is in range
        // and timer has counted above the shootspeed
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
                        GameObject bullet1 = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
                        Vector3 directionToEnemy1 = (enemyScript.transform.position + 
                                                    new Vector3(0, 0 + UnityEngine.Random.Range(-2f, 3f), 0) - 
                                                    transform.position).normalized;
                        bullet1.GetComponent<Rigidbody2D>().velocity = directionToEnemy1 * bulletSpeed;
                        Destroy(bullet1, bulletLifetime);

                        // at the last upgrade it shoots two arrows
                        if (lastTower)
                        {
                            GameObject bullet2 = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
                            Vector3 directionToEnemy2 = (enemyScript.transform.position +
                                                        new Vector3(0, 0 + UnityEngine.Random.Range(-2f, 3f), 0) -
                                                        transform.position).normalized;
                            bullet2.GetComponent<Rigidbody2D>().velocity = directionToEnemy2 * bulletSpeed;
                            Destroy(bullet2, bulletLifetime);
                        }
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
}
