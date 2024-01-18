using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class castle : MonoBehaviour
{
    public GameObject bar;
    private int health = 100;

    private void Update()
    {
        if (health <= 0)
        {
            ded();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1") && health > 0)
        {
            health -= 3;
            bar.transform.localScale = new Vector3(health, bar.transform.localScale.y, bar.transform.localScale.z);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("enemy2") && health > 0)
        {
            health -= 7;
            bar.transform.localScale = new Vector3(health, bar.transform.localScale.y, bar.transform.localScale.z);
            Destroy(collision.gameObject);
        }
    }

    public void ded()
    {
        SceneManager.LoadScene("ded");
    }
}
