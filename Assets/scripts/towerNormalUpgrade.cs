using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class towerNormalUpgrade : MonoBehaviour
{
    public GameObject towerPrefab;
    public towerNormal script;
    private shopSystem shop;

    private void Awake()
    {
        shop = GameObject.FindGameObjectWithTag("generalSystems").GetComponent<shopSystem>();
    }
    public void upgrade()
    {
        if (shop.inPocketCoins >= 50 && gameObject.name == "towerNormal(Clone)")
        {
            Destroy(gameObject);
            GameObject newTower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            shop.inPocketCoins -= 50;
        }
        if (shop.inPocketCoins >= 100 && gameObject.name != "towerNormal(Clone)")
        {
            Destroy(gameObject);
            GameObject newTower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            shop.inPocketCoins -= 100;
        }
    }
}
