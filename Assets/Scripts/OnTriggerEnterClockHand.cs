using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterClockHand : MonoBehaviour
{
    public SmoothenClockInteraction smoothenClockInteraction;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            smoothenClockInteraction.DisableOtherXRKnobs();
        }
    }
}
