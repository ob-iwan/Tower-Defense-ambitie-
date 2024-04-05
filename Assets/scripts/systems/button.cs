using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public towerSpawnerSystem spawnerScript;
    public shopSystem shopScript;
    public GameObject buttonObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if normalTower is buyable and not placing a tower activate button
        if (shopScript.normalPlaceAble && !spawnerScript.setNormal)
        {
            buttonObject.SetActive(true);
        }
        // if normal tower is not buyable and/or placing a tower deactivate button
        else if (!shopScript.normalPlaceAble || spawnerScript.setNormal) 
        { 
            buttonObject.SetActive(false); 
        }
    }
}
