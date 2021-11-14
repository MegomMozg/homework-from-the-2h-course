using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZoneCheck : MonoBehaviour
{
    public AudioReverbZone ReverbZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ReverbZone.enabled = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ReverbZone.enabled = false;
        }
    }
}
