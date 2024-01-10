using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpawnerSystem : MonoBehaviour
{
    public GameObject towerNormalEmptyPrefab;

    GameObject towerNormal;

    public bool setNormal;
    public bool hi;
    public Vector3 world;

    public void normal()
    {
        towerNormal = Instantiate(towerNormalEmptyPrefab, world + new Vector3(0f, 0f, 10f), Quaternion.identity);
        setNormal = true;
    }

    private void Update()
    {
        world = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (setNormal)
        {
            towerNormal.transform.position = world + new Vector3(0f, 0f, 10f);
            hi = true;
        }
        else if (hi && !setNormal)
        {
            Destroy(towerNormal.gameObject);
            hi = false;
        }
    }
}
