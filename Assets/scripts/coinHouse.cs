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
        if (shop.inPocketMeat >= 40 && shop.inPocketWood >= 80 && gameObject.name == "coinHouse")
        {
            Destroy(gameObject);
            GameObject newTower = Instantiate(housePrefab, transform.position, Quaternion.identity);
            shop.inPocketMeat -= 40;
            shop.inPocketWood -= 80;
            text.text = "cost: 100 meat and 145 wood";
        }

        if (shop.inPocketMeat >= 100 && shop.inPocketWood >= 145 && gameObject.name == "coinHouse2(Clone)")
        {
            Destroy(gameObject);
            GameObject newTower = Instantiate(housePrefab, transform.position, Quaternion.identity);
            shop.inPocketMeat -= 100;
            shop.inPocketWood -= 145;
            text.text = "cost: 210 meat and 270 wood";
        }

        if (shop.inPocketMeat >= 210 && shop.inPocketWood >= 270 && gameObject.name == "coinHouse3(Clone)")
        {
            Destroy(gameObject);
            GameObject newTower = Instantiate(housePrefab, transform.position, Quaternion.identity);
            shop.inPocketMeat -= 210;
            shop.inPocketWood -= 270;
            text.text = "Max upgraded";
        }
    }
}
