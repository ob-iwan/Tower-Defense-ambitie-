using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class towerNormal : MonoBehaviour
{
    public GameObject bulletPrefab;

    public CircleCollider2D circleCollider;

    public float shootSpeed;
    public float shotOffsetY;
    public float bulletLifetime;
    public float range;
    public float bulletSpeed;
    private enemy1 enemyScript;
    private float timer = 1f;

    private bool scriptGotten = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1") && !scriptGotten)
        {
            enemyScript = collision.GetComponent<enemy1>();
            scriptGotten = true;
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
                        Vector3 directionToEnemy = (enemyScript.transform.position + new Vector3(0, shotOffsetY, 0) - transform.position).normalized;
                        bullet.GetComponent<Rigidbody2D>().velocity = directionToEnemy * bulletSpeed;
                        Destroy(bullet, bulletLifetime);
                    }
                }
            }
        }
        if (scriptGotten && enemyScript.ded)
        {
            scriptGotten = false;
        }
    }
}
