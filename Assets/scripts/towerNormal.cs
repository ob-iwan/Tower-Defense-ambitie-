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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1"))
        {
            Debug.Log("boo");
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("enemy2"))
        {

        }
        if (collision.gameObject.CompareTag("enemy3"))
        {

        }
        if (collision.gameObject.CompareTag("enemy4"))
        {

        }
    }
}
