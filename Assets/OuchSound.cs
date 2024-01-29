using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuchSound : MonoBehaviour
{
    public AudioSource ouchSound;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ouchSound.Play();
        }
    }
}
