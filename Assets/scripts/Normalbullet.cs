using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Normalbullet : MonoBehaviour
{
    public int damage;

    public float bulletSpeed;

    Vector2 newForce;
    public float angle;

    float x;
    float y;

    Rigidbody2D rigidBody;

    private towerNormal towerScript;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        towerScript = GameObject.FindGameObjectWithTag("towerNormal").GetComponent<towerNormal>();
        angle = Vector2.Angle(transform.position, towerScript.enemyPosition);
        x = Mathf.Cos(angle * Mathf.PI) * bulletSpeed;
        y = Mathf.Sin(angle * Mathf.PI) * bulletSpeed;
        newForce = new Vector2(x, y);
        rigidBody.AddForce(newForce, ForceMode2D.Force);
    }

    void Start()
    {
        
    }

    void Update()
    {
        rigidBody.velocity = new Vector2(x, y);
    }
}
