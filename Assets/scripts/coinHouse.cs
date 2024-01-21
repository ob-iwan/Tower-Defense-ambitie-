using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class coinHouse : MonoBehaviour
{
    public float generation;
    private enemySpawner spawnerScript;
    private shopSystem shop;
    public GameObject housePrefab;
    public TextMeshProUGUI text;

    private float timer = 0;

    private void Awake()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("spawner").GetComponent<enemySpawner>();
        shop = GameObject.FindGameObjectWithTag("generalSystems").GetComponent<shopSystem>();
        text = GameObject.FindGameObjectWithTag("houseText").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerScript.timerInGameTime >= 10)
        {
            timer += generation * Time.deltaTime;
        }

        if (timer > 1)
        {
            shop.inPocketCoins += 1;
            timer = 0;
        }
    }

    public void upgrade()
    {
        if (shop.inPocketMeat >= 50 && shop.inPocketWood >= 80 && gameObject.name == "coinHouse")
        {
            Destroy(gameObject);
            GameObject newTower = Instantiate(housePrefab, transform.position, Quaternion.identity);
            shop.inPocketMeat -= 50;
            shop.inPocketWood -= 80;
            text.text = "cost: 150 meat and 170 wood";
        }

        if (shop.inPocketMeat >= 150 && shop.inPocketWood >= 170 && gameObject.name == "coinHouse2(Clone)")
        {
            Destroy(gameObject);
            GameObject newTower = Instantiate(housePrefab, transform.position, Quaternion.identity);
            shop.inPocketMeat -= 150;
            shop.inPocketWood -= 170;
            text.text = "cost: 360 meat and 370 wood";
        }

        if (shop.inPocketMeat >= 360 && shop.inPocketWood >= 370 && gameObject.name == "coinHouse3(Clone)")
        {
            Destroy(gameObject);
            GameObject newTower = Instantiate(housePrefab, transform.position, Quaternion.identity);
            shop.inPocketMeat -= 360;
            shop.inPocketWood -= 370;
            text.text = "Max upgraded";
        }
    }
}
