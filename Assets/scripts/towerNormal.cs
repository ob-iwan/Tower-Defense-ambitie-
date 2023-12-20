using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class towerNormal : MonoBehaviour
{
    public GameObject bulletPrefab;
    private CircleCollider2D circleCollider;

    public float shootSpeed;
    public float range;
    public Vector2 enemyPosition;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = range;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1"))
        {
            enemyPosition = collision.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        }
        //if (collision.gameObject.CompareTag("enemy2"))
        //{
        //    enemyPosition = collision.transform.position;
        //    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        //}
        //if (collision.gameObject.CompareTag("enemy3"))
        //{
        //    enemyPosition = collision.transform.position;
        //    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        //}
        //if (collision.gameObject.CompareTag("enemy4"))
        //{
        //    enemyPosition = collision.transform.position;
        //    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        //}

    }
}
