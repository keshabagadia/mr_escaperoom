using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShutSound : MonoBehaviour
{
    public AudioSource doorLocked;

    public void DoorShut()
    {
        doorLocked.Play();
    }
}
