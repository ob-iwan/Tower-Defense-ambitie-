using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{
    public ParticleSystem blood;

    private bool hi;

    // Update is called once per frame
    void Update()
    {
        if (blood.isPlaying)
        {
            hi = true;
        }
        if (hi == true && blood.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
