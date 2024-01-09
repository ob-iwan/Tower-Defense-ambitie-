using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class towerNormal : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float shootSpeed;
    public float range;
    public GameObject enemyPosition;
    private float timer = 1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < shootSpeed) 
        {
            timer += Time.deltaTime;
        }
        
        if (Vector3.Distance(transform.position, enemyPosition.transform.position) <= range)
        {
            if (timer >= 1f)
            {
                timer = 0f;
                GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
                Vector3 directionToPlayer = (enemyPosition.transform.position - transform.position).normalized;
                bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * 10f;
                Destroy(bullet, 2);
            }
        }
    }
}
