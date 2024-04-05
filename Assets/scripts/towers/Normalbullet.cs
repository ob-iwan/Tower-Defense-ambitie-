using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Normalbullet : MonoBehaviour
{
    public int damage;

    public float bulletSpeed;

    public float angle;


    private Rigidbody2D rigidBody;
    private towerNormal towerScript;
    private enemy1 enemyScript;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        towerScript = GameObject.FindGameObjectWithTag("towerNormal").GetComponent<towerNormal>();
    }
}
