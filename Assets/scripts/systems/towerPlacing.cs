using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Experimental.AI;

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
        // if placing a tower 
        if (spawnerSystem.setNormal)
        {
            // spawn a normal tower at mouse position
            if (Input.GetMouseButton(0) && spawnerSystem.world.y <= -4.46f)
            {
                towerNormal = Instantiate(normalPrefab, spawnerSystem.world + new Vector3(0f, 0f, spawnerSystem.world.y + 17f), Quaternion.identity);
                spawnerSystem.setNormal = false;
            }
        }
    }
}
