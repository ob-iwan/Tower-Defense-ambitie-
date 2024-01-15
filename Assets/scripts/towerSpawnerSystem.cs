using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpawnerSystem : MonoBehaviour
{
    public GameObject towerNormalEmptyPrefab;
    public shopSystem shopScript;

    GameObject towerNormal;

    public bool setNormal = false;
    public bool hi;
    public Vector3 world;

    public void normal()
    {
        // spawn placeholder normal tower at mouse position and setnormal (setting a tower) to true
        if (shopScript.normalPlaceAble)
        {
            towerNormal = Instantiate(towerNormalEmptyPrefab, world + new Vector3(0f, 0f, 10f), Quaternion.identity);
            setNormal = true;
        }
    }

    private void Update()
    {
        // get mouseposition
        world = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (setNormal)
        {
            // move placeholder tower with mouse
            towerNormal.transform.position = world + new Vector3(0f, 0f, 10f);
            hi = true;
        }
        else if (hi && !setNormal)
        {
            // destroy placeholder tower and set hi (hi means when you click on the ground when you place a tower) to true
            Destroy(towerNormal.gameObject);
            hi = false;
        }
    }
}
