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
        towerScript = GameObject.FindGameObjectWithTag("towerNormal").GetComponent<towerNormal>();
        angle = Vector2.Angle(transform.position, towerScript.enemyPosition);
        x = Mathf.Cos(angle * Mathf.PI / 180);
        y = Mathf.Sin(angle * Mathf.PI / 180);
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        newForce = new Vector2(x, y);

        rigidBody.velocity = new Vector2(0, 0);

        rigidBody.AddForce(newForce, ForceMode2D.Force);
    }
}
