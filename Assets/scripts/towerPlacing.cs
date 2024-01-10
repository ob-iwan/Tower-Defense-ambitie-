using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class towerPlacing : MonoBehaviour
{
    public GameObject normalPrefab;
    public towerSpawnerSystem spawnerSystem;

    GameObject towerNormal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerSystem.setNormal)
        {
            if (Input.GetMouseButton(0))
            {
                towerNormal = Instantiate(normalPrefab, spawnerSystem.world + new Vector3(0f, 0f, 10f), Quaternion.identity);
                spawnerSystem.setNormal = false;
            }
        }
    }
}
